using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class ScheduleReportsRequestModel
    {
        public List<string> AtmIds { get; set; }

        public string RegionIds { get; set; }        
    }
}
