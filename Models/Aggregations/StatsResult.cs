using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Aggregations
{
    public class StatsResult
    {
        public long Count { get; set; }
        public double? Average { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public double Sum { get; set; }
    }
}
