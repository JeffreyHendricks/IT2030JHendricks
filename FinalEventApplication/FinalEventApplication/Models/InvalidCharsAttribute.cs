using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalEventApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
            readonly string chars;


            public InvalidCharsAttribute(string newChar) : base("{0} has characters that are unnacceptable!")
        {
                chars = newChar;

            }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int i = 0;
                var valueAsString = value.ToString();
                var x = valueAsString;


                for (i = 0; i < chars.Length; i++)
                {
                    if (x.Contains(chars[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}