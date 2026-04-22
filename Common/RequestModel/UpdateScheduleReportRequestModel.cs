using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class UpdateScheduleReportRequestModel
    {
        public long ScheduleReportId { get; set; }
      
        public string ReportName { get; set; }

        public string ReportFriendlyName { get; set; }

        public string ReportsPhysicalPath { get; set; }

        public string ReportstTempPath { get; set; }

        public bool ScheduleType { get; set; }

        public int RetryCount { get; set; }

        public short? ExportType { get; set; }

        public int ExportDataOlderThan { get; set; }

        public int MinutesToScheduleAgain { get; set; }

        public string? Recipitents { get; set; }

        public string? CitName { get; set; }

        public bool ExportPDFChecked { get; set; }

        public bool ExportExcelChecked { get; set; }

        public DateTime NexrReportGeneratedAt { get; set; }

        public List<string> ScheduleReportTime { get; set; }

        //public List<string> SelectedAtms { get; set; }
    }
}
