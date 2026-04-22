using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class Dispensed
{
    public long AtmId { get; set; }

    public int CashRemaining1 { get; set; }

    public int CashRemaining2 { get; set; }

    public int CashRemaining3 { get; set; }

    public int CashRemaining4 { get; set; }

    public int CashRemaining5 { get; set; }

    public int CashRemaining6 { get; set; }

    public int CashRemaining7 { get; set; }

    public int CashDispensed1 { get; set; }

    public int CashDispensed2 { get; set; }

    public int CashDispensed3 { get; set; }

    public int CashDispensed4 { get; set; }

    public int CashDispensed5 { get; set; }

    public int CashDispensed6 { get; set; }

    public int CashDispensed7 { get; set; }

    public int CashPurged1 { get; set; }

    public int CashPurged2 { get; set; }

    public int CashPurged3 { get; set; }

    public int CashPurged4 { get; set; }

    public int CashPurged5 { get; set; }

    public int CashPurged6 { get; set; }

    public int CashPurged7 { get; set; }

    public DateTime ClearingDatetime { get; set; }

    public long DispensedId { get; set; }

    public long TaskId { get; set; }
}
