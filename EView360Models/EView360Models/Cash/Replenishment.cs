using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class Replenishment
{
    public long AtmId { get; set; }

    public int CashAdded1 { get; set; }

    public int CashAdded2 { get; set; }

    public int CashAdded3 { get; set; }

    public int CashAdded4 { get; set; }

    public int CashAdded5 { get; set; }

    public int CashAdded6 { get; set; }

    public int CashAdded7 { get; set; }

    public DateTime RepDatetime { get; set; }

    public string RepStatus { get; set; } = null!;

    public long ReplenishmentId { get; set; }

    public long TaskId { get; set; }

    public long? CashOrderId { get; set; }

    public bool IsSwap { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public bool? IsUpdated { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDatetime { get; set; }

    public long? GeneratedBy { get; set; }

    public string? Reason { get; set; }

    public decimal? RepAmount { get; set; }

    public int? LastTsn { get; set; }
}
