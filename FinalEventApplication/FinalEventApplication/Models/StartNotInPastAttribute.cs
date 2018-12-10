using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalEventApplication.Models
{
    public class StartNotInPastAttribute : ValidationAttribute
    {

        public StartNotInPastAttribute(): base("{0} is not a usable date.")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
                DateTime sd = (DateTime)value;
                if (sd >= DateTime.Now)
                {

                    return ValidationResult.Success;
                }
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
        }
    }
}