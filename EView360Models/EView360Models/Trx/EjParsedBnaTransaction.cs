using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjParsedBnaTransaction
{
    public long EjParsedBnaTransactionId { get; set; }

    public DateTime TrxnDatetime { get; set; }

    public string? TerminalId { get; set; }

    public string? Seq { get; set; }

    public string? AccountType { get; set; }

    public string? Pan { get; set; }

    public string? ConsumerMessageId { get; set; }

    public string? DisputeStatus { get; set; }

    public decimal? AmountAuthorized { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }

    public string? ProcessedTran { get; set; }

    public long AtmId { get; set; }

    public DateTime GeneratedAt { get; set; }

    public int StartIndex { get; set; }

    public int EndIndex { get; set; }

    public long TaskId { get; set; }

    public bool IsEligible { get; set; }

    public DateTime? TransactionStartTime { get; set; }

    public string? TransactionEndTime { get; set; }

    public string? CardTakenTime { get; set; }

    public bool? IsDisputedTransaction { get; set; }

    public string? HostTsn { get; set; }

    public string? AccountNo { get; set; }

    public DateTime? PostingDate { get; set; }

    public string? Currency { get; set; }

    public long? TransactionTypeId { get; set; }

    public string? Network { get; set; }

    public bool? IsCardless { get; set; }

    public long? CustomerId { get; set; }

    public string? BankName { get; set; }
}
