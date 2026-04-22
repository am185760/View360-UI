using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class DailyFeedConfig
{
    public long DailyFeedSchemeId { get; set; }

    public string DailyFeedFilePrefix { get; set; } = null!;

    public long RegionId { get; set; }
}
