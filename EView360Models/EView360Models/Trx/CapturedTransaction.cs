using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class CapturedTransaction
{
    public long CapturedTransactionsId { get; set; }

    public long TransactionRuleId { get; set; }

    public long TransactionId { get; set; }

    public DateTime CapturedAt { get; set; }

    public DateTime? ExpirationTime { get; set; }

    public long? UserId { get; set; }

    public string? Comments { get; set; }

    public long? EjCapturedCardId { get; set; }

    public decimal? AmountClaimed { get; set; }

    public long? EjParsedBnaTransactionsId { get; set; }

    public string? TrxnStatus { get; set; }

    public long? EjParsedTransactionsId { get; set; }

    public long? EjParsedCpmTransactionsId { get; set; }

    public long? TaskId { get; set; }

    public bool? IsLocked { get; set; }

    public decimal? AmountCredited { get; set; }

    public string? InternalTeamComment { get; set; }

    public DateTime? LockedDatetime { get; set; }

    public decimal? Amount { get; set; }

    public string? ModifiedBy { get; set; }
}
