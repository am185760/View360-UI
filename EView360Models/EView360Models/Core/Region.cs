using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class Region
{
    public long RegionId { get; set; }

    public string RegionName { get; set; } = null!;

    public long? ParentRegionId { get; set; }

    public string? Location { get; set; }

    public string? Country { get; set; }

    public long? RegionCitId { get; set; }

    public bool IsActive { get; set; }

    public long CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime CreationTime { get; set; }

    public virtual ICollection<ReportSchedule> ReportSchedules { get; } = new List<ReportSchedule>();
}
