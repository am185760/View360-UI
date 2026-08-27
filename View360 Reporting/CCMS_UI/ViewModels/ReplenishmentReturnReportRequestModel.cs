using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class ReplenishmentReturnReportRequestModel
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ReportTypeId { get; set; }

        public List<long> NoteSetTypeIds { get; set; }

        public List<string> SelectedAtms { get; set; }
    }
}