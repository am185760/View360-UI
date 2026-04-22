using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EView360Models.CustomValidationAttribute
{

    public class AtLeastOneRequired : ValidationAttribute
    {
        public string OtherPropertyNames;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPropertyNames">Multiple property name with comma(,) separator</param>
        public AtLeastOneRequired(string otherPropertyNames)
        {
            OtherPropertyNames = otherPropertyNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] propertyNames = OtherPropertyNames.Split(',');
            bool isAllNull = true;
            foreach (var i in propertyNames)
            {
                var p = validationContext.ObjectType.GetProperty(i);
                var val = p.GetValue(validationContext.ObjectInstance, null);
                if (val != null && val.ToString().Trim() != "")
                {
                    isAllNull = false;
                    break;
                }
            }

            if (isAllNull)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            else
            {
                return null;
            }
        }

    }
}
