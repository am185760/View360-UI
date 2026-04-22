namespace Common.RequestModel
{
    public class AlertMonitoringReportRequestModel
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string? type { get; set; }
        public List<string>? SelectedAtmIds { get; set; }
        public List<string>? SelectedRegionIds { get; set; }
        public int ArchiveYear { get; set; }
        public long UserId { get; set; }
    }
}
