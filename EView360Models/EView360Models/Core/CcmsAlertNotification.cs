using System;
using System.Collections.Generic;

namespace EView360Models.Core;

public partial class CcmsAlertNotification
{
    public long Id { get; set; }

    public long AlertTypeId { get; set; }

    //public long? OrganizationId { get; set; }

    public long UserId { get; set; }
}
