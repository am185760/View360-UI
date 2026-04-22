using System;
using System.Collections.Generic;

namespace EView360Models.Cash;

public partial class Atm
{
    public long AtmId { get; set; }

    public string? LastStatusReply { get; set; }

    public string Ip { get; set; } = null!;

    public int Port { get; set; }

    public bool IsActive { get; set; }

    public int IsRecycler { get; set; }
}
