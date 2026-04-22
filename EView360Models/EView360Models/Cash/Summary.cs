using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class Summary
{
    public long AtmId { get; set; }

    public decimal ClosingBalance { get; set; }

    public decimal Withdrawals { get; set; }

    public decimal PreWithdrawals { get; set; }

    public DateTime TrxnDatetime { get; set; }

    public decimal? ReturnAmount { get; set; }

    public decimal? ReplenishmentAmount { get; set; }

    public long SummaryId { get; set; }

    public int? CashRemaining1 { get; set; }

    public int? CashRemaining2 { get; set; }

    public int? CashRemaining3 { get; set; }

    public int? CashRemaining4 { get; set; }

    public int? CashRemaining5 { get; set; }

    public int? CashRemaining6 { get; set; }

    public int? CashRemaining7 { get; set; }

    public int? ReturnType1 { get; set; }

    public int? ReturnType2 { get; set; }

    public int? ReturnType3 { get; set; }

    public int? ReturnType4 { get; set; }

    public int? ReturnType5 { get; set; }

    public int? ReturnType6 { get; set; }

    public int? ReturnType7 { get; set; }

    public int? CashAdded1 { get; set; }

    public int? CashAdded2 { get; set; }

    public int? CashAdded3 { get; set; }

    public int? CashAdded4 { get; set; }

    public int? CashAdded5 { get; set; }

    public int? CashAdded6 { get; set; }

    public int? CashAdded7 { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public decimal? OpeningBalance { get; set; }

    public int? PurgedReturnType1 { get; set; }

    public int? PurgedReturnType2 { get; set; }

    public int? PurgedReturnType3 { get; set; }

    public int? PurgedReturnType4 { get; set; }

    public int? PurgedReturnType5 { get; set; }

    public int? PurgedReturnType6 { get; set; }

    public int? PurgedReturnType7 { get; set; }
}
