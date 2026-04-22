using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class AlertHistory
{
    public long AlertId { get; set; }

    public long LogId { get; set; }

    public int EscalationLevel { get; set; }

    public int ReminderNo { get; set; }

    public DateTime? SentAt { get; set; }

    public int RetriesLeft { get; set; }

    public bool IsSent { get; set; }

    public long UserId { get; set; }

    public int AlertInterface { get; set; }
}
