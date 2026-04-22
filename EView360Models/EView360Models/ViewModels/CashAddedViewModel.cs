namespace EView360Models.ViewModels
{
    public class CashAddedViewModel
    {
        public int AtmId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int DenominationType1 { get; set; } = 0;
        public int DenominationType2 { get; set; } = 0;
        public int DenominationType3 { get; set; } = 0;
        public int DenominationType4 { get; set; } = 0;
        public int? CashAdded1 { get; set; } = 0;
        public int? CashAdded2 { get; set; } = 0;
        public int? CashAdded3 { get; set; } = 0;
        public int? CashAdded4 { get; set; } = 0;
        public int? CashAdded5 { get; set; } = 0;
        public int? CashAdded6 { get; set; } = 0;
        public int? CashAdded7 { get; set; } = 0;
        public DateTime? RepDatetime { get; set; }
        public int LastTSN { get; set; }
        public int RowCount { get; set; }

    }
}
