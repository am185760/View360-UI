using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.RequestModel
{
    public class AlertMonitoringFilter
    {
        public DateTime? fromDate { get; set; } 
        public DateTime? toDate { get; set; } 
        public string type { get; set; }
        public List<string>? SelectedAtmIds { get; set; }
        public List<string>? SelectedRegionIds { get; set; }
        public int ArchiveYear { get; set; }
        public long UserId { get; set; }
        public int Offset { get; set; }
        public int RowCount { get; set; }
        public string? Orderby { get; set; }
    }
}
