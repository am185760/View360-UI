using System;
using System.Collections.Generic;

namespace EView360Models.Trx;

public partial class MState
{
    public long MstateId { get; set; }

    public string? MstateDesc { get; set; }

    public string? DeviceId { get; set; }

    public string? MStateCode { get; set; }

    public byte? MstateStatus { get; set; }
}
