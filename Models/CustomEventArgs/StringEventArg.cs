using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomEventArgs
{
    public class StringEventArg:EventArgs
    {
        public string Name { get; set; }
        public PartialProduct Product { get; set; }
        public StringEventArg(string name)
        {
            Name = name;
        }
        public StringEventArg(PartialProduct product)
        {
            Product = product;
        }
    }
}
