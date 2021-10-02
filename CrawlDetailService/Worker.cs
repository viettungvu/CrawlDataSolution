using ES;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;
using Models.Links;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Utils;
using static Models.AllEnums;

namespace CrawlDetailService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Data mining...");
            while (!stoppingToken.IsCancellationRequested)
            {
                await MineData();
                await Task.Delay(300000, stoppingToken);
            }
            _logger.LogInformation("Done...");
        }
        private async Task MineData()
        {
            int currPage = 1;
            int pageCount = 1;
            while (currPage <= pageCount)
            {
                var response = await LinkRepository.Instance.GetAll(new Models.Pagings.PagingRequestBase() { PageIndex = currPage, PageSize = 100 });
                if (response.IsSuccess)
                {
                    currPage += 1;
                    pageCount = response.Data.PageCount;
                    Parallel.ForEach(response.Data.Items, async (link) =>
                    {
                        var newLink = await GetLinkDetail(link.Path);
                        link.LastCrawl = newLink.DateCreated;
                        link.Status = newLink.Status;
                        link.ProductDescription = newLink.ProductDescription;
                        if (link.ProductPrice != newLink.ProductPrice)
                        {
                            link.ProductPrice = newLink.ProductPrice;
                            link.LastUpdate = DateTime.Now;
                            _logger.LogInformation($"Link {link.Id} has changed price");
                        }
                        if (!string.IsNullOrEmpty(link.ProductId))
                        {
                            var res = ProductRepository.Instance.GetById(link.ProductId);
                            if (res.IsSuccess)
                            {
                                if (link.ProductPrice < res.Data.Price || res.Data.Price == -1)
                                {
                                    res.Data.Price = link.ProductPrice;
                                    await ProductRepository.Instance.Update(res.Data);
                                    _logger.LogInformation($"Product {res.Data.Id} has changed price");
                                }
                            }
                        }
                        LinkRepository.Instance.Update(link);
                    });
                }
                else
                {
                    pageCount = -1; 
                    _logger.LogError($"No links in ES");
                }
            }
        }
        private async Task<ProductLink> GetLinkDetail(string link)
        {
            var res = await client.GetAsync(link);
            if (res.IsSuccessStatusCode)
            {
                string html = await res.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(html))
                {
                    string price = AllUtils.GetRegexString(html, Constant.PRICE_DETAIL_PATTERN, "data");
                    price = AllUtils.GetRegexString(price, Constant.DECIMAL_GSEPARATOR_PARTTERN);

                    string tskt = AllUtils.GetRegexString(html, Constant.P_PARAMS_PARTTERN, "data");
                    MatchCollection collection = AllUtils.GetCollectionRegex(tskt, Constant.PARAM_PARTTERN);
                    string description = "";
                    Parallel.ForEach(collection, (m) =>
                    {
                        string title = AllUtils.GetRegexString(m.Groups["data"].Value, Constant.TITLE_PARTTERN, "data");
                        description += title + "\n";
                        string body = AllUtils.GetRegexString(m.Groups["data"].Value, Constant.P_DESCRIPT_LISTDETAIL_PARTTERN, "data");
                        MatchCollection content = AllUtils.GetCollectionRegex(body, Constant.P_DESCRIPT_DETAIL_PARTTERN);
                        foreach (Match c in content)
                        {
                            description += "-" + c.Groups["data"].Value;
                            description += "\n";
                        }
                    });
                    ProductLink productLink = new()
                    {
                        Path = link,
                        Status = LinkStatus.SUCCESS,
                        ProductDescription = description,
                        DateCreated = DateTime.Now,
                    };
                    try
                    {
                        productLink.ProductPrice = price.ConvertToLong();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }
                    return productLink;
                }
                else
                {
                    _logger.LogError("Empty HTML");
                    return new ProductLink() { Path = link, Status = LinkStatus.SUCCESS, DateCreated = DateTime.Now, ProductPrice = -1 };
                }
            }
            else
            {
                _logger.LogError($"{link} is unreachable");
                return new ProductLink() { Path = link, Status = LinkStatus.ERROR, DateCreated =DateTime.Now, ProductPrice = -1 };
            }
        }
    }
}
