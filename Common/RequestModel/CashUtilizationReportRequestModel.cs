using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class CashUtilizationReportRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public List<long> NoteSetTypeIds { get; set; }

        public string ArchiveYear { get; set; }

        public long UserId { get; set; }

        public List<string> SelectedAtms { get; set; }
        public List<string> SelectedRegionIds { get; set; }
    }
}
