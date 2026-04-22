using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class CpmCountsCleared
{
    public long CpmCountsClearedId { get; set; }

    public long AtmId { get; set; }

    public DateTime CountsClearedAt { get; set; }

    public DateTime RecordedAt { get; set; }
}
