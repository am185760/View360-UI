using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class NoCashWithdrawalReportRequestModel
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public long UserId { get; set; }
        public List<string>? SelectedAtmIds { get; set; }
        public int ArchiveYear { get; set; }
        public bool isDeadATMExcluded { get; set; }

    }
}
