using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class ReportTask
{
    public long ReportTaskId { get; set; }

    public long ReportScheduleId { get; set; }

    public string? FilePathAttachment { get; set; }

    public int RetryCount { get; set; }

    public string? FailureReason { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? LastInvokedAt { get; set; }

    public string Status { get; set; } = null!;

    public DateTime ScheduleDate { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public long? AtmId { get; set; }
}
