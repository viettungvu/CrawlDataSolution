using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.AllEnums;

namespace Models.Products
{
    public class PartialProduct
    {
        public string Id { get; set; }
        public long Price { get; set; }
        public int TotalLinks { get; set; }
    }
}
