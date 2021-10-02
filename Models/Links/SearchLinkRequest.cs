using Models.Pagings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.AllEnums;

namespace Models.Links
{
    public class SearchLinkRequest:PagingRequestBase
    {
        public string ProductName { get; set; }
        public string Domain { get; set; }
        public long? LowPrice { get; set; }
        public long? HighPrice { get; set; }
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }
        public LinkStatus? Status { get; set; }
        public DateTime? LastUpdateFrom { get; set; }
        public DateTime? LastUpdateTo { get; set; }
        public bool IsBelongToAnyProduct { get; set; }
    }
}
