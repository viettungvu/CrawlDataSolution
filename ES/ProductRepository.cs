using Models;
using Models.Aggregations;
using Models.Links;
using Models.Pagings;
using Models.Products;
using Models.Responses;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace ES
{
    public class ProductRepository : IESRepository
    {
        protected static string _defaultIndex = "";
        public ProductRepository(string modifyIndex)
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
            client.Map<Product>(m => m.AutoMap().Dynamic(false));
        }
        private static ProductRepository instance;
        public static ProductRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    _defaultIndex = "products_index";
                    instance = new ProductRepository(_defaultIndex);
                }
                return instance;
            }
        }
        public async Task<Response<bool>> Create(Product p)
        {
            //Kiểm tra xem đã tồn tại sản phẩm nào tương tự trong db chưa theo cả tên, model và hãng
            var checkRequest = new GetProductRequest()
            {
                Name = p.Name,
                Model = p.Model,
                Brand = p.Brand
            };
            var productExisted = await GetFirstProduct(checkRequest);
            if (productExisted != null) //đã tồn tại sản phẩm có tên tương tự trong db
            {
                productExisted.Brand = string.IsNullOrEmpty(p.Brand) ? productExisted.Brand : p.Brand;
                productExisted.Model = string.IsNullOrEmpty(p.Model) ? productExisted.Model : p.Model;
                productExisted.Description = string.IsNullOrEmpty(p.Description) ? productExisted.Description : p.Description;
                productExisted.Price = p.Price;
                productExisted.Status = p.Status;
                productExisted.TotalLinks = p.TotalLinks;
                return await Update(productExisted); //tiến hành cập nhật lại sản phẩm
            }
            else
            {
                var resCre = Index(_defaultIndex, p, null);
                if (resCre)
                {
                    return new ResponseSuccess<bool>(true);
                }
            }
            return new ResponseError<bool>($"Can not create product. Please try again");
        }
        public bool UpdatePartial(PartialProduct product)
        {
            var res = client.Update<Product, PartialProduct>(product.Id, des => des.Doc(product));
            return res.Result == Result.Updated;
        }
        public Response<PagedResult<Product>> GetAllProduct(PagingRequestBase request)
        {
            var searchReq = new SearchRequest<Product>()
            {
                Query = new MatchAllQuery() { },
                From = ((request.PageIndex - 1) * request.PageSize),
                Size = request.PageSize
            };
            var response = client.Search<Product>(searchReq);
            if (response.Documents.Count < 1)
                return new ResponseError<PagedResult<Product>>("Products is empty");
            var data = response.Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                }).ToList();
            var paged = new PagedResult<Product>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
                TotalRecords = response.HitsMetadata.Total.Value //response.Documents.Count
            };
            return new ResponseSuccess<PagedResult<Product>>(paged);

        }
        public async Task<Product> GetFirstProduct(GetProductRequest request)
        {
            List<QueryContainer> filter = new();
            if (!string.IsNullOrEmpty(request.Name))
            {
                var query = new QueryStringQuery { Fields = "name", Query = request.Name, DefaultOperator = Operator.And };
                filter.Add(query);
            }
            if (!string.IsNullOrEmpty(request.Model))
            {
                var query = new QueryStringQuery { Fields = "model", Query = request.Model, DefaultOperator = Operator.And };
                filter.Add(query);
            }
            if (!string.IsNullOrEmpty(request.Brand))
            {
                var query = new QueryStringQuery { Fields = "brand", Query = request.Brand, DefaultOperator = Operator.And };
                filter.Add(query);
            }
            var req = new SearchRequest()
            {
                Query = new BoolQuery
                {
                    Filter = filter,
                },
                Size = 1,
            };
            var res = await client.SearchAsync<Product>(req);
            var data = res.Hits
                .Select(x =>
                {
                    x.Source.Id = x.Id;
                    return x.Source;
                }).FirstOrDefault();
            return data;
        }
        public Response<Product> GetById(string id)
        {
            var response = client.Get<Product>(new GetRequest(_defaultIndex, id));
            if (response.Found)
            {
                return new ResponseSuccess<Product>(response.Source);
            }
            return new ResponseError<Product>("Product not found");
        }
        public async Task<Response<bool>> Update(Product p)
        {
            var resUp = await Task.Run(() => Update(_defaultIndex, p, p.Id));
            if (resUp)
                return new ResponseSuccess<bool>();
            return new ResponseError<bool>($"Can not update product {p.Id}");
        }
        public Response<bool> Delete(string id, bool cascadeOnDelete=false)
        {
            bool isSuccess;
            var resDel = Delete<Product>(_defaultIndex, id);
            if (resDel)
            {
                var links = LinkRepository.Instance.GetLinkByProductId(id);
                if (links.Count > 0)
                {
                    if (cascadeOnDelete)
                    {
                        isSuccess = LinkRepository.Instance.DeleteMany(links);
                    }
                    else
                    {
                        isSuccess = LinkRepository.Instance.ResetProductId(links);
                    }
                    if (isSuccess)
                    {
                        return new ResponseSuccess<bool>();
                    }
                }
                return new ResponseSuccess<bool>();
            }
            return new ResponseError<bool>($"Can not remove product with id {id}");
        }
        public Response<PagedResult<Product>> Search(SearchProductRequest request)
        {
            /* tim kiem
             * 1. ten
             * 2. khoang gia
             * 3. ngay tao
             * 4. so luong link
             */
            List<QueryContainer> must = new();
            List<QueryContainer> filter = new();

            if (!string.IsNullOrEmpty(request.ProductName))
            {
                var query = new QueryStringQuery
                {
                    Fields = new string[] { "name", "brand", "model" },
                    Query = request.ProductName
                };
                must.Add(query);
            }

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

            if (request.LowQuantity.HasValue)
            {
                var query = new LongRangeQuery
                {
                    Field = "totalLinks",
                    GreaterThanOrEqualTo = request.LowQuantity.Value
                };
                filter.Add(query);
            }
            if (request.HighQuantity.HasValue)
            {
                var query = new LongRangeQuery
                {
                    Field = "totalLinks",
                    LessThanOrEqualTo = request.HighQuantity.Value
                };
                filter.Add(query);
            }

            var searchRequest = new SearchRequest()
            {
                Query = new BoolQuery
                {
                    Filter = filter,
                    Must = must
                },
                From = ((request.PageIndex - 1) * request.PageSize),
                Size = request.PageSize
            };
            var res = client.Search<Product>(searchRequest);
            if (res.Total < 1)
                return new ResponseError<PagedResult<Product>>("Không có kết quả");
            var data = res.Hits
                .Select(h =>
                {
                    h.Source.Id = h.Id;
                    return h.Source;
                }).ToList();
            var paged = new PagedResult<Product>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data,
                TotalRecords = res.Total,
            };
            return new ResponseSuccess<PagedResult<Product>>(paged);
        }
        public StatsResult Analyze()
        {
            var request = new SearchRequest
            {
                Query = new MatchAllQuery { },
                Aggregations = new StatsAggregation("thong_ke", "totalLinks")
                {
                    Field = "totalLinks",
                }
            };
            var res = client.Search<Product>(request);
            var statsresult = res.Aggregations.Stats("thong_ke");
            return new StatsResult()
            {
                Count=statsresult.Count,
                Average=statsresult.Average,
                Min=statsresult.Min,
                Max=statsresult.Max,
                Sum=statsresult.Sum
            };
        }
    }
}
