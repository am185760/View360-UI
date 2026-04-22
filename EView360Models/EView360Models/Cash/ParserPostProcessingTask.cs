using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class ParserPostProcessingTask
{
    public long ParserPostProcessingTaskId { get; set; }

    public string EventType { get; set; } = null!;

    public string? EventInfo { get; set; }

    public long EntityId { get; set; }

    public DateTime EventOccuredAt { get; set; }

    public long TaskId { get; set; }

    public long AtmId { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? ProcessedTime { get; set; }
}
