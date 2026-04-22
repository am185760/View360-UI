using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class AtmSummaryReportViewModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public string AtmType { get; set; }
        public List<long> NoteSetTypes { get; set; }
        public long UserId { get; set; }
        public List<string>? SelectedAtmIds { get; set; }
        public List<string>? SelectedRegionIds { get; set; }
        public int ArchiveYear { get; set; }

    }
}
