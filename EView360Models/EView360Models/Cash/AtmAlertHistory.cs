using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class AtmAlertHistory
{
    public long? AtmId { get; set; }

    public long AtmAlertId { get; set; }

    public DateTime GeneratedAt { get; set; }

    public DateTime? ResolveAt { get; set; }

    public long AlertTypeId { get; set; }

    public DateTime? ExpirationTime { get; set; }

    public int GenerateAtRetryRemaining { get; set; }

    public int ResolveAtRetryRemaining { get; set; }

    public DateTime? LastInvokedAt { get; set; }

    public bool? GenerateNotificationSent { get; set; }

    public bool? ResolveNotificationSent { get; set; }

    public string? FailureReason { get; set; }

    public string? AlertMsg { get; set; }

    public long? TaskId { get; set; }

    public string? EntityType { get; set; }

    public long? EntityId { get; set; }

    public int? EventCount { get; set; }
}
