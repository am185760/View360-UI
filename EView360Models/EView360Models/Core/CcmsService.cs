using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class CcmsService
{
    public long CcmsServicesId { get; set; }

    public string Name { get; set; } = null!;

    public string ServiceStatus { get; set; } = null!;

    public DateTime? LastInvokedAt { get; set; }

    public bool? IsStartScheduled { get; set; }

    public bool? IsStopScheduled { get; set; }
}
