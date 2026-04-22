namespace EView360Models.ViewModels
{
    public class AtmSummaryStatusModel
    {
        public List<string>? atmTiles { get; set; }
        public int trnx_count_today { get; set; }
        public int trnx_count_yesterday { get; set; }
    }
}
