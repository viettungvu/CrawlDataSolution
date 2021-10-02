using ES;
using Models.Links;
using Models.Pagings;
using Models.Products;
using Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class LinkService
    {
        public async Task<Response<PagedResult<ProductLink>>> GetAll(PagingRequestBase request)
        {
            return await LinkRepository.Instance.GetAll(request);
        }
        public Response<bool> Update(ProductLink link)
        {
            var res= LinkRepository.Instance.Update(link);
            if (res)
            {
                return new ResponseSuccess<bool>();
            }
            return new ResponseError<bool>("Cập nhật thất bại");
        }
        public Response<bool> Delete(string id)
        {
            var res= LinkRepository.Instance.Delete(id);
            if (res)
            {
                return new ResponseSuccess<bool>();
            }
            return new ResponseError<bool>("Xóa thất bại");
        }
        public async Task<Response<PagedResult<ProductLink>>> Search(SearchLinkRequest request)
        {
            return await LinkRepository.Instance.Search(request);
        }
        public Response<bool> Assign(List<PartialLink> partialLinks, PartialProduct product)
        {
            var res = LinkRepository.Instance.Assign(partialLinks, product);
            if (res)
            {
                return new ResponseSuccess<bool>();
            }
            return new ResponseError<bool>("Gán link thất bại");
        }
        public async Task<Response<bool>> UnAssign(List<PartialLink> unLinks)
        {
            var res=await LinkRepository.Instance.UnAssign(unLinks);
            if (res)
            {
                return new ResponseSuccess<bool>();
            }
            return new ResponseError<bool>("Hủy gán thất bại"); 
        }
        public long Analyze(AnalyzeLinkRequest request)
        {
            return LinkRepository.Instance.AggregationLink(request);
        }
    }
}
