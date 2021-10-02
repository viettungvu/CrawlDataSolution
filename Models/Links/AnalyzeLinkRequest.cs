using Models.Pagings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Links
{
    public class AnalyzeLinkRequest : PagingRequestBase
    {
        public string Domain { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
