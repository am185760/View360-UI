using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.CustomValidationAttribute
{
    public class RequiredIfOtherFieldHasValueAttribute : ValidationAttribute
    {
        private readonly string _otherFieldName;

        public RequiredIfOtherFieldHasValueAttribute(string otherFieldName)
        {
            _otherFieldName = otherFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherField = validationContext.ObjectType.GetProperty(_otherFieldName);
            var otherFieldValue = otherField.GetValue(validationContext.ObjectInstance);

            if (otherFieldValue != null && !string.IsNullOrEmpty(otherFieldValue.ToString()))
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
