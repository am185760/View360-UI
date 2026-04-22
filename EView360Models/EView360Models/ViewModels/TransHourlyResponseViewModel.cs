namespace EView360Models.ViewModels
{
    public class TransHourlyResponseViewModel
    {
        public long AtmId { get; set; }
        public DateTime? TrnxDateTime { get; set; }
        public DateTime? LastHeartBeatAt { get; set; }
        public decimal? Amount { get; set; }
    }
}
