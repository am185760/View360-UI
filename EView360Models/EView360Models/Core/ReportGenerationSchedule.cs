using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class ReportGenerationSchedule
{
    public long ReportGenerationScheduleId { get; set; }

    public DateTime NextGenerationAt { get; set; }

    public long ReportScheduleId { get; set; }
}
