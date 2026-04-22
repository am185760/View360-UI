using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.RequestModel
{
    public class BNATransactionRequestModel
    {
        public DateTime? fromDate { get; set; }

        public DateTime? toDate { get; set; }

        public string ArchiveYear { get; set; }
        public long  UserId { get; set; }

        public List<string> SelectedAtmIds { get; set; }

        public List<string> SelectedRegionIds { get; set; }

        public int offset { get; set; }

        public int rowCount { get; set; }

        public string? Orderby { get; set; }
    }
}
