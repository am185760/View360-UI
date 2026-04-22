using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class Alert
{
    public long AlertId { get; set; }

    public long? AtmId { get; set; }

    public bool? Status { get; set; }

    public DateTime GeneratedAt { get; set; }

    public DateTime? ResolveAt { get; set; }

    public long AlertTypeId { get; set; }

    public string? Source { get; set; }

    public long? FtpFileInfoId { get; set; }

    public string? AlertData { get; set; }

    public DateTime? ExpirationTime { get; set; }
}
