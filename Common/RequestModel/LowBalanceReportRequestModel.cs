using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class LowBalanceReportRequestModel
    {
        public DateTime FromDate { get; set; }
        
        public DateTime ToDate { get; set; }
        
        public bool IsCurrent { get; set; }

        public List<long> NoteSetTypeIds { get; set; }

        public List<string> SelectedAtms { get; set; }

        public List<string> SelectedRegionIds { get; set; }

        public string ArchiveYear { get; set; }

        public bool isDeadATMExcluded { get; set; }

        public int? minThreshold { get; set; }

        public int? maxThreshold { get; set; }
        public long UserId { get; set; }
    }
}
