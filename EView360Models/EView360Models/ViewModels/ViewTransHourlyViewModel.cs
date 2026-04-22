namespace EView360Models.ViewModels
{
    public class ViewTransHourlyViewModel
    {
        public long AtmId { get; set; }
        public string? Title { get; set; }
        public DateTime? GenerationTime { get; set; }
        public decimal?  Amount { get; set; }
        public DateTime? LastHeartBeatAt { get; set; }
        public bool? IsHealthy { get; set; }
        public string? Ip { get; set; }
        public string? Location { get; set; }
    }
}
