using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EView360Models.Core;

public partial class AlertType
{
    public long AlertTypeId { get; set; }

    public string AlertTypeName { get; set; } = null!;

    public string? AlertAdditionalText { get; set; }

    public string AlertDefaultText { get; set; } = null!;

    public bool? SendEmailNotification { get; set; }

    public bool? OpenTicketInGasper { get; set; }

    public string? TpaCode { get; set; }

    public string? TpaValue { get; set; }

    [NotMapped]
    public bool isSelected { get; set; } = false;
}
