using ES;
using Models;
using Models.Aggregations;
using Models.Pagings;
using Models.Products;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductService
    {
        public async Task<Response<bool>> Create(Product p)
        {
            return await ProductRepository.Instance.Create(p);
        }
        public Response<PagedResult<Product>> GetAll(PagingRequestBase request)
        {
            return ProductRepository.Instance.GetAllProduct(request);
        }
        public Response<Product> GetById(string id)
        {
            return ProductRepository.Instance.GetById(id);
        }
        public async Task<Response<bool>> Update(Product p)
        {
            return await ProductRepository.Instance.Update(p);
        }
        public Response<bool> Delete(string id)
        {
            return ProductRepository.Instance.Delete(id);
        }
        public Response<PagedResult<Product>> Search(SearchProductRequest request)
        {
            return ProductRepository.Instance.Search(request);
        }
        public StatsResult Analyze()
        {
            return ProductRepository.Instance.Analyze();
        }
    }
}
