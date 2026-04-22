using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EView360Models.Core;

public partial class Right
{
    public long RightId { get; set; }

    public string? Name { get; set; }

    public string? RightType { get; set; }

    public string? EntityType { get; set; }

    [NotMapped]
    public bool IsSelected { get; set; }
    public virtual ICollection<GroupRight> GroupRights { get; } = new List<GroupRight>();
}
