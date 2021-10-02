using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.AllEnums;

namespace Models.Links
{
    public class PartialLink
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public long ProductPrice { get; set; }
    }
}
