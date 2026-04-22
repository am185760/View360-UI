namespace EView360Models.ViewModels
{
    public class CashPositionViewModel
    {
        public int RowCount { get; set; }
        public long CashPositionId { get; set; }
        public string? Ip { get; set; }
        public string? NoteSetTypeName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public long AtmId { get; set; }
        public string? AtmTitle { get; set; }
        public DateTime LastTrxnAt { get; set; }
        public DateTime LastSuccessfulTrxnAt { get; set; }
        public decimal? TotalCashBalance { get; set; }
        public decimal? TotalPurgedCashBalance { get; set; }
        public DateTime LastReplenishmentAt { get; set; }
        public decimal? TotalRemaining { get; set; }
        public int? PurgedNotes { get; set; }
        public int? PurgedAmount { get; set; }
        public DateTime? NextReplenishmentAt { get; set; }
        public decimal? Amount { get; set; }
        public int? DenominationType1 { get; set; }
        public int? DenominationType2 { get; set; }
        public int? DenominationType3 { get; set; }
        public int? DenominationType4 { get; set; }
        public int? DenominationType5 { get; set; }
        public int? DenominationType6 { get; set; }
        public int? DenominationType7 { get; set; }
        public int Cassette1Denomination { get; set; }
        public int Cassette2Denomination { get; set; }
        public int Cassette3Denomination { get; set; }
        public int Cassette4Denomination { get; set; }
        public int Cassette5Denomination { get; set; }
        public int Cassette6Denomination { get; set; }
        public int Cassette7Denomination { get; set; }
        public int? PurgeCassette1Notes { get; set; }
        public int? PurgeCassette2Notes { get; set; }
        public int? PurgeCassette3Notes { get; set; }
        public int? PurgeCassette4Notes { get; set; }
        public int? PurgeCassette5Notes { get; set; }
        public int? PurgeCassette6Notes { get; set; }
        public int? PurgeCassette7Notes { get; set; }
        public decimal? MinOperatingBalance { get; set; }
    }
}
