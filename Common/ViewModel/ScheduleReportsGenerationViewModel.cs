using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ScheduleReportsGenerationViewModel
    {
        public string Organizations { get; set; }
        
        public string ReportName  { get; set; }
        
        public string ReportFriendlyName  { get; set; }
        
        public int ReportScheduleId  { get; set; }
        
        public string ReportsPhysicalPath  { get; set; }
        
        public string ReportstTempPath  { get; set; }
        
        public int ScheduleType  { get; set; }

        public int RetryCount  { get; set; }

        public int ExportType  { get; set; }

        public int ExportDataOlderThan  { get; set; }

        public int MinutesToScheduleAgain  { get; set; }

        public string? Recipitents  { get; set; }

        public string? CitName  { get; set; }
    }
}
