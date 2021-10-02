using Models;
using Models.Links;
using Models.Pagings;
using Models.Products;
using Models.Responses;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ES
{
    public class LinkRepository : IESRepository
    {
        protected static string _defaultIndex = "";
        public LinkRepository(string modifyIndex)
        {
            _defaultIndex = !string.IsNullOrEmpty(modifyIndex) ? modifyIndex : _defaultIndex;
            ConnectionSettings settings = new ConnectionSettings(connectionPool).DefaultIndex(_defaultIndex).DisableDirectStreaming(true);
            settings.MaximumRetries(10);
            client = new ElasticClient(settings);
            var ping = client.Ping(p => p.Pretty(true));
            if (ping.ServerError != null && ping.ServerError.Error != null)
            {
                throw new Exception("START ES FIRST");
            }
            client.Map<ProductLink>(m => m.AutoMap().Dynamic(false));
        }
        private static LinkRepository instance;
        public static LinkRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    _defaultIndex = "product_link_index";
                    instance = new LinkRepository(_defaultIndex);
                }
                return instance;
            }
        }
        public bool Index(ProductLink link)
        {
            var existLink = GetLinkExist(link.Path);
            if (existLink != null) //đã tồn tại link trong db
            {
                existLink.ProductName = link.ProductName;
                existLink.ProductBranch = link.ProductBranch;
                existLink.ProductDescription = link.ProductDescription;
                existLink.ProductModel = link.ProductModel;
                existLink.LastCrawl = link.DateCreated;
                existLink.Status = link.Status;
                if (existLink.ProductPrice != link.ProductPrice)
                {
                    existLink.ProductPrice = link.ProductPrice;
                    existLink.LastUpdate = DateTime.Now;
                }
                return Update(existLink);
            }
            return Index(_defaultIndex, link, null);
        }
        public bool Update(ProductLink p)
        {
            return Update(_defaultIndex, p, p.Id);
        }
        //Tìm ra link đã tồn tại trong db
        private ProductLink GetLinkExist(string link)
        {
            var req = new SearchRequest()
            {
                Query = new BoolQuery
                {
                    Filter = new QueryContainer[]{new  MatchQuery
                    {
                        Field = "path",
                        Query = link,
                        Operator=Operator.And
                    }}
                },
                Size = 1,
            };
            var res = client.Search<ProductLink>(req);
            if (res.Total > 0)
            {
                return res.Hits
                    .Select(h =>
                    {
                        h.Source.Id = h.Id;
                        return h.Source;
                    }).First();
            }
            return null;
        }
        //Lấy ra danh sách link 
        public async Task<Response<PagedResult<ProductLink>>> GetAll(PagingRequestBase request)
        {
            var req = new SearchRequest<ProductLink>()
            {
                Query = new BoolQuery
                {
                    Filter = new QueryContainer[] { new MatchAllQuery { } },
                },
                From = (request.PageIndex - 1) * request.PageSize,
                Size = request.PageSize,
            };
            var response = await client.SearchAsync<ProductLink>(req);
            if (response.Total < 1)
            {
                return new ResponseError<PagedResult<ProductLink>>("Không có dữ liệu");
            }
            var productLinks = response.Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                }).ToList();
            var data = new PagedResult<ProductLink>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = productLinks,
                TotalRecords = response.Total
            };
            return new ResponseSuccess<PagedResult<ProductLink>>(data);
        }
        //Lấy tất cả các link thuộc về id sản phẩm productId
        public List<ProductLink> GetLinkByProductId(string productId)
        {
            var req = new SearchRequest
            {
                Query = new BoolQuery
                {
                    Filter = new QueryContainer[]
                    {
                        new MatchQuery{ Field="productId", Query=productId}
                    }
                }
            };
            var res = client.Search<ProductLink>(req);
            var data = res.Hits
           .Select(h =>
           {
               h.Source.Id = h.Id;
               return h.Source;
           }).ToList();
            return data;
        }
        //Xóa link theo id
        public bool Delete(string id)
        {
            return Delete<ProductLink>(_defaultIndex, id);
        }
        //Xóa nhiều link cùng lúc
        public bool DeleteMany(List<ProductLink> links)
        {
            List<ProductLink> errorLinks = new();
            Parallel.ForEach(links, (link) =>
            {
                var res = Delete<ProductLink>(_defaultIndex, link.Id);
                if (!res)
                {
                    errorLinks.Add(link);
                }
            });
            return errorLinks.Count != 0;
        }
        //Tìm kiếm link theo các tiêu chí được chọn trong request
        public async Task<Response<PagedResult<ProductLink>>> Search(SearchLinkRequest request)
        {
            List<QueryContainer> must = new();
            List<QueryContainer> filter = new();
            /*1 Tên sản phẩm*/
            if (!string.IsNullOrEmpty(request.ProductName))
            {
                var query = new QueryStringQuery
                {
                    Fields = new string[] { "productName", "productBrand", "productModel" },
                    Query = request.ProductName,
                };
                must.Add(query);
            }
            /*2 Domain*/
            if (!string.IsNullOrEmpty(request.Domain))
            {
                string regex = $".*{request.Domain}.*";
                var query = new RegexpQuery
                {
                    Field = "path",
                    Value = regex
                };
                must.Add(query);
            }
            /*3 Trạng thái*/
            if (request.Status.HasValue)
            {
                var term = new TermQuery
                {
                    Field = "status",
                    Value = request.Status
                };
                filter.Add(term);
            }
            /*4 Khoảng giá*/
            if (request.LowPrice.HasValue)
            {
                var query = new LongRangeQuery
                {
                    Field = "price",
                    GreaterThanOrEqualTo = request.LowPrice
                };
                filter.Add(query);
            }
            if (request.HighPrice.HasValue)
            {
                var query = new LongRangeQuery
                {
                    Field = "price",
                    LessThanOrEqualTo = request.HighPrice
                };
                filter.Add(query);
            }
            /*5 Ngày tạo*/
            if (request.DateCreatedFrom.HasValue)
            {
                var query = new DateRangeQuery
                {
                    Field = "dateCreated",
                    GreaterThanOrEqualTo = request.DateCreatedFrom
                };
                filter.Add(query);
            }
            if (request.DateCreatedTo.HasValue)
            {
                var query = new DateRangeQuery
                {
                    Field = "dateCreated",
                    LessThanOrEqualTo = request.DateCreatedTo
                };
                filter.Add(query);
            }
            /*6 Ngày cập nhật*/
            if (request.LastUpdateFrom.HasValue)
            {
                var query = new DateRangeQuery
                {
                    Field = "lastUpdate",
                    GreaterThanOrEqualTo = request.LastUpdateFrom
                };
                filter.Add(query);
            }
            if (request.LastUpdateTo.HasValue)
            {
                var query = new DateRangeQuery
                {
                    Field = "lastUpdate",
                    LessThanOrEqualTo = request.LastUpdateTo
                };
                filter.Add(query);
            }
            /*7 Đã thuộc về sản phẩm nào chưa*/
            if (request.IsBelongToAnyProduct)
            {
                var query = new TermQuery
                {
                    Field = "productId",
                    Value = "",
                };
                filter.Add(query);
            }
            var searchRequest = new SearchRequest()
            {
                Query = new BoolQuery
                {
                    Must = must,
                    Filter = filter,
                },
                From = ((request.PageIndex - 1) * request.PageSize),
                Size = request.PageSize,
            };
            var res = await client.SearchAsync<ProductLink>(searchRequest);
            if (res.Total < 1)
            {
                return new ResponseError<PagedResult<ProductLink>>("Không có kết quả");
            }
            var data = res.Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                }).ToList();
            var paged = new PagedResult<ProductLink>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
                TotalRecords = res.Total
            };
            return new ResponseSuccess<PagedResult<ProductLink>>(paged);
        }
        //Reset lại field productId khi sản phẩm bị xóa
        public bool ResetProductId(List<ProductLink> links)
        {
            int count = links.Count;
            Parallel.ForEach(links, (link) =>
            {
                link.ProductId = null;
                var res = client.Update<ProductLink, object>(link.Id, des => des.Doc(new { ProductId = "" })).Result == Result.Updated;
                count = res ? count - 1 : count;
            });
            return count == 0;
        }
        public bool Assign(List<PartialLink> links, PartialProduct product)
        {
            if (product != null && links.Count > 0) //nếu tổn tại thì mới gán được, còn không thì quay ra tạo sản phẩm rồi gán
            {
                bool isChanged = false; //Báo rằng có link được gán, nếu không thì không cần update
                links.ForEach(link =>
                {
                    if (link.ProductId != product.Id)
                    {
                        link.ProductId = product.Id; //thông báo rằng link này có product id là product này
                        product.TotalLinks += 1; //Đồng thời tăng số lượng link của sản phẩm đó thêm 1
                        if (product.Price > link.ProductPrice || product.Price == -1)
                        {
                            product.Price = link.ProductPrice;
                        }
                        isChanged = true;
                    }
                });
                if (isChanged)
                {
                    var updateResponse = ProductRepository.Instance.UpdatePartial(product);
                    if (updateResponse)
                    {
                        var bulkResponse = client.Bulk(b => b.UpdateMany(links, (bu, d) => bu.Doc(d)));
                        return !bulkResponse.Errors;
                    }
                }
            }
            return false;
        }
        public async Task<bool> UnAssign(List<PartialLink> unLinks)
        {
            int empty = 0;
            int unempty = 0;
            foreach (var link in unLinks)
            {
                if (!string.IsNullOrEmpty(link.ProductId))
                {
                    var res = ProductRepository.Instance.GetById(link.ProductId);
                    if (res.IsSuccess)
                    {
                        var product = res.Data;
                        product.TotalLinks -= 1;
                        if (product.Price != link.ProductPrice)
                        {
                            product.Price = link.ProductPrice;
                        }
                        await ProductRepository.Instance.Update(product);
                    }
                    var resUp = client.Update<ProductLink, object>(link.Id, des => des.Doc(new { ProductId = "" }));
                    if (resUp.Result == Result.Updated)
                    {
                        unempty += 1;
                    }
                }
                else
                {
                    empty += 1;
                }
            }
            return empty + unempty == unLinks.Count;
        }
        public long AggregationLink(AnalyzeLinkRequest request)
        {
            /* Thong ke
             * 1. Trong domain xxx.com bao nhieu link bi thay doi gia trong range(from, to)
             */
            List<QueryContainer> must = new();
            if (!string.IsNullOrEmpty(request.Domain))
            {
                string regex = $".*{request.Domain}.*";
                var query = new RegexpQuery
                {
                    Field = "path",
                    Value = regex,
                };
                must.Add(query);
            }
            List<DateRangeExpression> ranges = new();
            if (request.FromDate.HasValue)
            {
                if (request.ToDate.HasValue)
                {
                    ranges.Add(new DateRangeExpression { Key = "in_range", From = request.FromDate, To = request.ToDate });
                }
                else
                {
                    ranges.Add(new DateRangeExpression { Key = "after", From = request.FromDate });
                }
            }
            else
            {
                if (request.ToDate.HasValue)
                {
                    ranges.Add(new DateRangeExpression { Key = "before", To= request.ToDate });
                }
            }

            var searchRequest = new SearchRequest<ProductLink>
            {
                Query = new BoolQuery
                {
                    Must = must
                },
                Aggregations = new DateRangeAggregation("price_changed_count")
                {
                    Field = "lastUpdate",
                    Ranges = ranges
                }
            };
            var res = client.Search<ProductLink>(searchRequest);
              var aggResult=res.Aggregations.DateRange("price_changed_count");
            return aggResult.Buckets.FirstOrDefault().DocCount;
        }
    }
}
