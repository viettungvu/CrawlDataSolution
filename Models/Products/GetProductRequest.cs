using Models.Pagings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Products
{
    public class GetProductRequest:PagingRequestBase
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
