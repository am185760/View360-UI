using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class DepositPosition
{
    public long AtmId { get; set; }

    public long DepositPositionId { get; set; }

    public int? Cassette1Deposit { get; set; }

    public int? Cassette2Deposit { get; set; }

    public int? Cassette3Deposit { get; set; }

    public int? Cassette4Deposit { get; set; }

    public int? PurgeDeposit { get; set; }

    public int? Bin1 { get; set; }

    public int? Bin2 { get; set; }

    public int? Bin3 { get; set; }

    public int? Bin4 { get; set; }

    public DateTime? LastCpmDepositAt { get; set; }

    public DateTime? LastBnaDepositAt { get; set; }

    public string? Cassette1DepositValue { get; set; }

    public string? Cassette2DepositValue { get; set; }

    public string? Cassette3DepositValue { get; set; }

    public string? Cassette4DepositValue { get; set; }

    public string? PurgeDepositValue { get; set; }
}
