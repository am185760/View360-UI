using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class GroupRight
{
    public long GroupId { get; set; }

    public long RightId { get; set; }

    public long GroupRightsId { get; set; }
    public virtual Group? Group { get; set; }

    public virtual Right? Right { get; set; }
}
