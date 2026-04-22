using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class OrganizationAlert
{
    public long OrganizationAlertId { get; set; }

    public DateTime GeneratedAt { get; set; }

    public long AlertTypeId { get; set; }

    public long FtpFileInfoId { get; set; }

    public DateTime ExpirationTime { get; set; }

    public int RetryRemaining { get; set; }

    public DateTime? LastInvokedAt { get; set; }

    public bool GenerateNotificationSent { get; set; }

    public string? FailureReason { get; set; }

    public string? AlertMsg { get; set; }
}
