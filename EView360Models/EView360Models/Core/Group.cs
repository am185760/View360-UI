using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EView360Models.Core;

public partial class Group
{
    public long GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string? Description { get; set; }

    public string? EntityType { get; set; }

    public long? CreatedBy { get; set; }

    public long? OrganizationId { get; set; }

    public bool? SendIndividualAlert { get; set; }

    public string? GroupEmail { get; set; }

    public bool? IsAdded { get; set; }

    public bool? IsEditied { get; set; }

    public bool? IsDeleted { get; set; }
    
    [NotMapped]
    public bool isSelected { get; set; } = false;

    public string? Status { get; set; }
    public virtual ICollection<GroupRight> GroupRights { get; } = new List<GroupRight>();

    public virtual ICollection<GroupUser> GroupUsers { get; } = new List<GroupUser>();
}
