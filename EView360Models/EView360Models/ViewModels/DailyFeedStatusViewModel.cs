using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class DailyFeedStatusViewModel
    {
        public int FtpFileId { get; set; }
        public string? FileName { get; set; }
        public string? TaskType { get; set; }
        public string? Status { get; set; }
        public string? FailureReason { get; set; }
        public int RetryCount { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? LastInvokedAt { get; set; }
    }
}
