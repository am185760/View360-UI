using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class CashDepositDenominationRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public List<string> SelectedAtms { get; set; }

        public List<string> SelectedRegionIds { get; set; }

        public string ArchiveYear { get; set; }
        public string tsn { get; set; }
        public string status { get; set; }

    }
}
