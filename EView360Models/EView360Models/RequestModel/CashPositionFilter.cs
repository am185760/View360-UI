using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.RequestModel
{
    public class CashPositionFilter
    {
        public DateTime? date { get; set; }
        public DateTime? fromDate { get; set; }

        public DateTime? toDate { get; set; }

        public List<string>? AtmIds { get; set; }

        public string Filter { get; set; }

        public string Values { get; set; }
        public bool isRegionSelected { get; set; }

        public List<string>? NoteSetTypeIds { get; set; }

        public int? MinNotesAlertExists { get; set; }
        public string? OrderBy { get; set; }
        public string? SpName { get; set; }
        public int? archiveYear { get; set; }
        public int offset { get; set; }
        public int rowCount { get; set; }
    }
}
