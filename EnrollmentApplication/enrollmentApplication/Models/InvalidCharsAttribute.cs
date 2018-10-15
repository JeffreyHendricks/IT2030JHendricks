using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace enrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string chars;
        readonly string bChars;
        readonly string cChars;

        public InvalidCharsAttribute(string newChar) : base("{0} has characters that are unnacceptable!")
        {
            chars = newChar;
            
        }

        public InvalidCharsAttribute(string newChar, string bChar) : base("{0} has characters that are unnacceptable!")
        {
            chars = newChar;
            bChars = bChar;
            
        }

        public InvalidCharsAttribute(string newChar, string bChar, string cChar):base("{0} has characters that are unnacceptable!")
        {
            chars = newChar;
            bChars = bChar;
            cChars = cChar;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int i = 0;
                var valueAsString = value.ToString();
                var x = valueAsString;
                

               for(i = 0; i < valueAsString.Length; i++)
                {
                    if (x.Contains(chars[i])|| x.Contains(bChars[i])|| x.Contains(cChars[i]))
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