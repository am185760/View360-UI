namespace Common.RequestModel
{
    public class ReplenishmentReportRequestModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public List<long>? NoteSetTypeIds { get; set; }
        public int ReportType { get; set; }
        public string Status { get; set; }
        public List<string>? SelectedAtmIds { get; set; }
        public List<string>? SelectedRegionIds { get; set; }
        public int ArchiveYear { get; set; }
        public long UserId { get; set; }
    }
}
