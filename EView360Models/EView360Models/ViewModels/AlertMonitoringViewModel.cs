using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AlertMonitoringViewModel
    {
        public string AlertTypeName { get; set; }
        public string Title { get; set; }
        public string RegionName { get; set; }
        public DateTime? GeneratedAt { get; set; }
        public DateTime? ResolveAt { get; set; }
        public string AlertMsg { get; set; }
        public long AtmId { get; set; }
        public int RowCount { get; set; }

    }
}
