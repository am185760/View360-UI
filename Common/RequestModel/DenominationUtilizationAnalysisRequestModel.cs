using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class DenominationUtilizationAnalysisRequestModel
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public long? notesetTypeId { get; set; }
        public List<string>? SelectedAtmIds { get; set; }
        public List<string>? SelectedRegionIds { get; set; }
        public long UserId { get; set; }
    }
}
