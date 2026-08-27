using System;
using System.Collections.Generic;

namespace CCMSUI.ViewModels
{
    public class CashWithdrawalReportRequestModel
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public List<long> NoteSetTypeIds { get; set; }
        public int reportType { get; set; }
        public int? PurgeNoteFrom { get; set; }
        public int? PurgeNoteTo { get; set; }
        public int? FromAmount { get; set; }
        public int? ToAmount { get; set; }
        public int? DispensedType1 { get; set; }
        public int? DispensedType2 { get; set; }
        public int? DispensedType3 { get; set; }
        public int? DispensedType4 { get; set; }
        public int? Threshold { get; set; }
        public List<string> SelectedAtmIds { get; set; }
        public int ArchiveYear { get; set; }
    }
}