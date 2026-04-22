using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class AuditLog
{
    public long AuditLogId { get; set; }

    //public string Activity { get; set; } = null!;

    public long RightId { get; set; }

    public long UserId { get; set; }

    public DateTime ActivityTime { get; set; }

    public string? Message { get; set; }

    public List<AuditLogDetail> AuditLogDetails { get; set; }
}
