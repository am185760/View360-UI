using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class EjParsedTransaction
{
    public long EjParsedTransactionsId { get; set; }

    public string? Tsn { get; set; }

    public string? Pan { get; set; }

    public DateTime TrxnDatetime { get; set; }

    public decimal? Amount { get; set; }

    public int? NotesDispensedType1 { get; set; }

    public int? NotesDispensedType2 { get; set; }

    public int? NotesDispensedType3 { get; set; }

    public int? NotesDispensedType4 { get; set; }

    public long? AtmId { get; set; }

    public long? TaskId { get; set; }

    public long? MstateId { get; set; }

    public long? CommentId { get; set; }

    public long? TransactionTypeId { get; set; }

    public decimal? AvailableBalance { get; set; }

    public DateTime? ProcessingDatetime { get; set; }

    public int? StartIndex { get; set; }

    public int? EndIndex { get; set; }

    public int? Status { get; set; }

    public decimal? DonationAmount { get; set; }

    public decimal? TransferredAmount { get; set; }

    public int? NotesRemainingType1 { get; set; }

    public int? NotesRemainingType2 { get; set; }

    public int? NotesRemainingType3 { get; set; }

    public int? NotesRemainingType4 { get; set; }

    public int? NotesDispensedType5 { get; set; }

    public int? NotesDispensedType6 { get; set; }

    public int? NotesDispensedType7 { get; set; }

    public DateTime? TransactionStartTime { get; set; }

    public string? TransactionEndTime { get; set; }

    public string? CardTakenTime { get; set; }

    public string? AccountType { get; set; }

    public string? Result { get; set; }

    public string? ConsumerMessageId { get; set; }

    public string? DisputeStatus { get; set; }

    public string? TerminalId { get; set; }

    public bool? IsDisputedTransaction { get; set; }

    public DateTime? PostingDate { get; set; }

    public string? Currency { get; set; }

    public bool? IsEligible { get; set; }

    public string? Network { get; set; }

    public int? NotesRejectedType1 { get; set; }

    public int? NotesRejectedType2 { get; set; }

    public int? NotesRejectedType3 { get; set; }

    public int? NotesRejectedType4 { get; set; }

    public string? HostTsn { get; set; }

    public bool? IsCardless { get; set; }

    public int? NotesRemainingType5 { get; set; }

    public int? NotesRemainingType6 { get; set; }

    public int? NotesRemainingType7 { get; set; }

    public int? NotesRejectedType5 { get; set; }

    public int? NotesRejectedType6 { get; set; }

    public int? NotesRejectedType7 { get; set; }

    public string? BankName { get; set; }
}
