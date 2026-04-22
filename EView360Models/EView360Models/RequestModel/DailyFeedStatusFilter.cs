namespace EView360Models.RequestModel
{
    public class DailyFeedStatusFilter
    {
        public DateTime? CreationFrom { get; set; }
        public DateTime? CreationTo { get;set; }
        public DateTime? EndFrom { get; set; }
        public DateTime? EndTo { get; set;}
        public string? Status { get; set; }
        public string? TaskType { get; set; }
        public List<string> SelectedAtmIds;

    }
}
