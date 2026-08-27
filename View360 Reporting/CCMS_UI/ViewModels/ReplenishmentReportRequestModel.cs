using System;
using System.Collections.Generic;

namespace CCMSUI.ViewModels
{
    public class ReplenishmentReportRequestModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public List<long> NoteSetTypeIds { get; set; }
        public string ReportType { get; set; }
        public string Status { get; set; }
        public List<string> SelectedAtmIds { get; set; }
        public int ArchiveYear { get; set; }
    }
}