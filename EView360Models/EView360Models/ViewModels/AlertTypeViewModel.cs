using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.ViewModels
{
    public class AlertTypeViewModel
    {
        public long AlertTypeId { get; set; }

        public string AlertTypeName { get; set; } = null!;

        [RegularExpression(@"^[^,!@#$%^&*'()|=]+$", ErrorMessage = "Additional text has invalid character")]
        public string? AlertAdditionalText { get; set; }

        public string AlertDefaultText { get; set; } = null!;

        public bool? SendEmailNotification { get; set; }

        public bool? OpenTicketInGasper { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "Max length for TPA Code is 10")]
        [RegularExpression(@"^[^,!@#$%^&*'()|=]+$", ErrorMessage = "TPA Code has invalid character")]
        public string? TpaCode { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "Max length for TPA Value is 10")]
        [RegularExpression(@"^[^,!@#$%^&*'()|=]+$", ErrorMessage = "TPA Value has invalid character")]
        public string? TpaValue { get; set; }
    }
}
