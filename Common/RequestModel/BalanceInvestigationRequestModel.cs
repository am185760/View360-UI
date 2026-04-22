using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestModel
{
    public class BalanceInvestigationRequestModel
    {
        public List<long> NoteSetTypeIds { get; set; }

        public DateTime? FromDate { get; set; }
        
        public DateTime? ToDate { get; set; }
        
        public string? AtmIP { get; set; }
        public bool ShowBillColumn { get; set; }

        public int? ArchiveYear { get; set; }
        
        public int offset { get; set; }

        public int rowCount { get; set; }
        public long UserId { get; set; }

        public List<string> SelectedAtmIds { get; set; }
        public List<string> SelectedRegionIds { get; set; }

        public string? Orderby { get; set; }

    }
}
