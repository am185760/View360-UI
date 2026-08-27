using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class OutOfCashReportRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsCurrent { get; set; }

        public List<int> NoteSetTypeIds { get; set; }

        public List<string> SelectedAtms { get; set; }

        public int ArchiveYear { get; set; }
    }
}