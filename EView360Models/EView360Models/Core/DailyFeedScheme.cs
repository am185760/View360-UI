using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class DailyFeedScheme
{
    public string Mcn { get; set; } = null!;

    public bool IsSplitByCountry { get; set; }

    public long DailyFeedSchemeId { get; set; }
}
