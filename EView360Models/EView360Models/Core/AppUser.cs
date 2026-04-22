using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EView360Models.Core;

public partial class AppUser
{
    public long UserId { get; set; }

    [Required(ErrorMessage = "Login ID is required")]
    public string UserLogin { get; set; } = null!;

    public string? UserPassword { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    public string UserFullName { get; set; }

    public DateTime? UserLastLoginTime { get; set; }

    public long UserCreatedBy { get; set; }

    public DateTime UserCreationTime { get; set; }

    public long? UserModifiedBy { get; set; }

    public DateTime? UserModificationTime { get; set; }

    public bool UserIsActive { get; set; }

    public string? UserEmail { get; set; }

    public long? CitId { get; set; }

    public string? UserType { get; set; }

    public long? ManagerId { get; set; }

    public bool IsActiveDirectoryUser { get; set; }

    public long? EmployeeManagerId { get; set; }

    public string? MobileNumber { get; set; }

    public int? RetryAttempt { get; set; }

    public string? ApprovalStatus { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsEditied { get; set; }

    public bool? IsAdded { get; set; }

    [NotMapped]
    public bool isSelected { get; set; } = false;

    public virtual ICollection<GroupUser> GroupUsers { get; } = new List<GroupUser>();
}
