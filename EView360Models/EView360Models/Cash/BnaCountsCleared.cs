using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class BnaCountsCleared
{
    public long BnaCountsClearedId { get; set; }

    public long AtmId { get; set; }

    public DateTime CountsClearedAt { get; set; }

    public DateTime RecordedAt { get; set; }

    public long? TaskId { get; set; }
}
