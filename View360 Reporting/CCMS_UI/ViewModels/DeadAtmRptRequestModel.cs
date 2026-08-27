using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class DeadAtmRptRequestModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<string> SelectedAtms { get; set; }
        public string SelectedNoteSetType { get; set; }
        public bool isCurrent { get; set; }
        public int? archiveYear { get; set; }
    }
}