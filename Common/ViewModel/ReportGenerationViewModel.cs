using EView360Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ReportGenerationViewModel
    {
        public long ScheduleReportGenerationId { get; set; }

        public DateTime? NextGenerationAt { get; set; }

        public long ScheduleReportId { get; set; }


        public static explicit operator ReportGenerationViewModel(ReportGenerationSchedule model)
        {
            if (model == null)
            {
                return null;
            }

            ReportGenerationViewModel result = new ReportGenerationViewModel();
            result.ScheduleReportGenerationId = model.ReportGenerationScheduleId;
            result.NextGenerationAt = model.NextGenerationAt;
            result.ScheduleReportId = model.ReportScheduleId;
            return result;
        }
    }
}
