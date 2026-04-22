using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjParsedCpmTransaction
{
    public long EjParsedCpmTransactionId { get; set; }

    public DateTime TrxnDatetime { get; set; }

    public string? TerminalId { get; set; }

    public string? Seq { get; set; }

    public string? AccountType { get; set; }

    public string? Pan { get; set; }

    public decimal? DepositAmount { get; set; }

    public string? Result { get; set; }

    public string? ConsumerMessageId { get; set; }

    public string? DisputeStatus { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }

    public string? RejectReason { get; set; }

    public string? ProcessedTran { get; set; }

    public long AtmId { get; set; }

    public DateTime GeneratedAt { get; set; }

    public decimal? DispenseAmount { get; set; }

    public int StartIndex { get; set; }

    public int EndIndex { get; set; }

    public long TaskId { get; set; }

    public bool IsEligible { get; set; }

    public bool? IsDisputedTransaction { get; set; }

    public string? HostTsn { get; set; }

    public string? AccountNo { get; set; }

    public string? Micr { get; set; }

    public long? TransactionTypeId { get; set; }

    public string? Network { get; set; }

    public bool? IsCardless { get; set; }

    public string? BankName { get; set; }
}
