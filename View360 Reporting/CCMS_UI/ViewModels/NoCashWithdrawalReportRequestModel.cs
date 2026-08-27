using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCMSUI.ViewModels
{
    public class NoCashWithdrawalReportRequestModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long UserId { get; set; }
        public List<string> SelectedAtmIds { get; set; }
        public int ArchiveYear { get; set; }
    }
}