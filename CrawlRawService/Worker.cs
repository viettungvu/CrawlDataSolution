using ES;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models.Links;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Utils;
using static Models.AllEnums;

namespace CrawlRawService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;

        private readonly List<Uri> baseUri = new List<Uri>
        {
            //new Uri("https://www.dienmayxanh.com/tivi") ,
            new Uri("https://www.dienmayxanh.com/tivi#c=1942&o=9&pi=13"),
        };
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
            _logger.LogInformation($"Data mining...");
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (Uri link in baseUri)
                {
                    await Crawl(link);
                }
                await Task.Delay(3000000, stoppingToken);
            }
            _logger.LogInformation($"Done...");
        }
        public async Task Crawl(Uri baseLink)
        {
            var result = await GetLinks(baseLink);
            Parallel.ForEach(result, (link) =>
            {
                var res = LinkRepository.Instance.Index(link);
                if (res == false)
                {
                    _logger.LogError($"Link {link.Id} is not saved to ES");
                }
            });
        }
        private async Task<List<ProductLink>> GetLinks(Uri link)
        {
            string domain = AllUtils.GetRegexString(link.ToString(), Constant.DOMAIN1_PARTTERN, "domain");
            var response = await client.GetAsync(link);
            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();
                List<ProductLink> productLinks = new();
                string ul = AllUtils.GetRegexString(html, Constant.UL_PARTTERN);
                MatchCollection li = AllUtils.GetCollectionRegex(ul, Constant.LI_PARTTERN);
                Parallel.ForEach(li, (m) =>
                {
                    string a_tag = m.Groups["data"].Value;
                    string href = AllUtils.GetRegexString(a_tag, Constant.A_PARTTERN, "link");
                    string attribute = AllUtils.GetRegexString(a_tag, Constant.A_PARTTERN, "attribute");

                    string brand = AllUtils.GetRegexString(attribute, Constant.P_BRAND_PARTTERN, "brand");
                    string name = AllUtils.GetRegexString(attribute, Constant.P_NAME_PARTTERN, "name");
                    string price = AllUtils.GetRegexString(a_tag, Constant.P_PRICE_PARTTERN, "price");
                    long pPrice = -1;
                    if (string.IsNullOrEmpty(price))
                    {
                        price = AllUtils.GetRegexString(a_tag, Constant.DECIMAL_GSEPARATOR_PARTTERN, "data");
                    }
                    try
                    {
                        pPrice = price.ConvertToLong();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }
                    string a_tag_data = AllUtils.GetRegexString(a_tag, Constant.A_PARTTERN, "data");
                    string brief = AllUtils.GetRegexString(a_tag_data, Constant.P_DESCRIPT_PARTTERN, "data");
                    brief = AllUtils.GetStringCollection(brief, Constant.SPAN_PARTTERN, "data");
                    //Model thường nằm ở cuối tên sản phẩm(Điện máy xanh +Nguyen Kim)
                    string[] temp = name.Split(" ");
                    string model = temp[^1];

                    var productLink = new ProductLink()
                    {
                        Path = domain + href,
                        ProductName = name,
                        ProductBranch = brand,
                        ProductModel = model,
                        ProductPrice = pPrice,
                        ProductDescription = brief,
                        Status = LinkStatus.NEW,
                        DateCreated = DateTime.Now,
                        LastUpdate = DateTime.Now,
                        LastCrawl = DateTime.Now,
                        ProductId = "",
                    };
                    productLinks.Add(productLink);
                });
                return productLinks;
            }
            _logger.LogError($"{link} is unreachable");
            return null;
        }
    }
}
