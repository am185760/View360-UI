using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class OutOfCashReportRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsCurrent { get; set; }

        public List<long> NoteSetTypeIds { get; set; }

        public List<string> SelectedAtms { get; set; }

        public List<string>? SelectedRegionIds { get; set; }

        public int ArchiveYear { get; set; }
        public bool isDeadATMExcluded { get; set; }
        public long UserId { get; set; }
    }
}
