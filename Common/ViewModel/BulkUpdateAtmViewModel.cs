using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class BulkUpdateAtmViewModel
    {
        public long AtmId { get; set; }
        public long RegionId { get; set; }
        public int MinOperatingBalance { get; set; }
        public int OutOfCashThreshold { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
