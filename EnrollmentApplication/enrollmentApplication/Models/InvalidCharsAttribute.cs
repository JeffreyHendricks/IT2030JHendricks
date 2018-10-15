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
       

        public InvalidCharsAttribute(string badChar, string badChar2, string badChars3):base("{0} has characters that are unnacceptable!")
        {
            chars = badChar;
            bChars = badChar2;
            cChars = badChars3;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int i = 0;
                var valueAsString = value.ToString();
                var x = valueAsString;

                while (i < valueAsString.Length)
                {
                    
                    x = valueAsString.Substring(i);


                    if (x.Equals(chars)|| x.Equals(bChars)|| x.Equals(cChars))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);

                        return new ValidationResult(errorMessage);

                    }
                    else
                    {
                        i++;
                    }

                }
            }
                
            return ValidationResult.Success;
        }
    }
}