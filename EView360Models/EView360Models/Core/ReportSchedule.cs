using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class ReportSchedule
{
    public long ReportScheduleId { get; set; }

    public string ReportName { get; set; } = null!;

    public string? ReportPhysicalPath { get; set; }

    public string ReportReceipients { get; set; } = null!;

    public string ReportTempPath { get; set; } = null!;

    public int RetryCount { get; set; }

    public DateTime ReportNextGeneratedAt { get; set; }

    public string ReportFriendlyName { get; set; } = null!;

    public int? MinutesToScheduleAgain { get; set; }

    public short? ReportExportType { get; set; }

    public int? ReportDataAge { get; set; }

    public bool ScheduleType { get; set; }

    public long? OrganizationId { get; set; }

    public bool IsEjEnabled { get; set; }

    public string? ReportVirtualDirPath { get; set; }

    public bool IsGraphicalReport { get; set; }

    public long? CriteriaId { get; set; }

    public bool IsWeekly { get; set; }

    public bool IsMonthly { get; set; }

    public string? ApplicableNoteSetType { get; set; }

    public long? CitId { get; set; }

    public virtual Region? Region { get; set; }
}
