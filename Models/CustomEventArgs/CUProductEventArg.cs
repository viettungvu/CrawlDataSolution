using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomEventArgs
{
    public class CUProductEventArg:EventArgs
    {
        public Product Product { get; set; }
        public CUProductEventArg(Product value)
        {
            Product = value;
        }
    }
}
