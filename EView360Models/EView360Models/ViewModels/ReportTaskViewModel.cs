using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class ReportTaskViewModel
    {
        public DateTime? CreationTime { get; set; }
        public string? ReportName { get; set; }
        public int? RetryCount { get; set; }
        public string? Status { get; set; }
        public string? FailureReason { get; set; }
    }
}
