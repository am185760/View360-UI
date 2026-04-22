using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class AtmStat
{
    public long AtmId { get; set; }

    public long? TaskId { get; set; }

    public long? OfflineTaskId { get; set; }

    public DateTime? MaxTrxnAt { get; set; }

    public DateTime? MaxRepAt { get; set; }
}
