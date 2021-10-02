using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.AllEnums;

namespace Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public long Price { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public int TotalLinks { get; set; }
    }
}
