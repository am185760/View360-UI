using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class AlertMonitoringReportRequestModel
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string type { get; set; }
        public List<string> SelectedAtmIds { get; set; }
        public int ArchiveYear { get; set; }

    }
}