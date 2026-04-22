using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class ParsedCpmCounter
{
    public long ParsedCpmCounterId { get; set; }

    public int? Bin1 { get; set; }

    public int? Bin2 { get; set; }

    public int? Bin3 { get; set; }

    public int? Bin4 { get; set; }

    public long AtmId { get; set; }

    public long TaskId { get; set; }

    public DateTime DepositAt { get; set; }
}
