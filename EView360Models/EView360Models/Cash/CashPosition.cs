using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class CashPosition
{
    public long CashPositionId { get; set; }

    public long AtmId { get; set; }

    public int? Cassette1Notes { get; set; }

    public int? Cassette2Notes { get; set; }

    public int? Cassette3Notes { get; set; }

    public int? Cassette4Notes { get; set; }

    public int? Cassette5Notes { get; set; }

    public int? Cassette6Notes { get; set; }

    public int? Cassette7Notes { get; set; }

    public long TaskId { get; set; }

    public DateTime LastTrxnAt { get; set; }

    public int? PurgeCassette1Notes { get; set; }

    public int? PurgeCassette2Notes { get; set; }

    public int? PurgeCassette3Notes { get; set; }

    public int? PurgeCassette4Notes { get; set; }

    public int? PurgeCassette5Notes { get; set; }

    public int? PurgeCassette6Notes { get; set; }

    public int? PurgeCassette7Notes { get; set; }

    public decimal? TotalCashBalance { get; set; }

    public decimal? TotalPurgedCashBalance { get; set; }
}
