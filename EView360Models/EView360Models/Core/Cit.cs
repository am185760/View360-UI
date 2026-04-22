using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class Cit
{
    public long CitInternalId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? Id { get; set; }

    public string? TeamId { get; set; }

    public string? CcId { get; set; }

    public long CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime CreationTime { get; set; }

    public bool? IsActive { get; set; }
}
