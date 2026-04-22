using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class GroupUser
{
    public long UserId { get; set; }

    public long GroupId { get; set; }

    public long GroupUsersId { get; set; }
    public virtual Group? Group { get; set; }

    public virtual AppUser? User { get; set; }
}
