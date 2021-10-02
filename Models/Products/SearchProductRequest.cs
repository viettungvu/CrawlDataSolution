using Models.Pagings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Products
{
    public class SearchProductRequest:PagingRequestBase
    {
        public string ProductName { get; set; }
        public long? LowPrice { get; set; }
        public long? HighPrice { get; set; }
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }
        public int? LowQuantity { get; set; }
        public int? HighQuantity { get; set; }
    }
}
