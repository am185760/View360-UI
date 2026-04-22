using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class DailyFeedSchedule
{
    public long DailyFeedScheduleId { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public long CreatedBy { get; set; }

    public DateTime CreationTime { get; set; }

    public bool IsExecuted { get; set; }

    public string Mcn { get; set; } = null!;

    public int RetryCount { get; set; }

    public string? FailureReason { get; set; }

    public long? AtmId { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public bool? DeleteCurrentData { get; set; }

    public bool? EnableDffGeneration { get; set; }
}
