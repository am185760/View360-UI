using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class ReportGenerationRequestModel
    {
        public int ScheduleReportId { get; set; }

        public List<string> selectedAtms { get; set; }
    }
}
