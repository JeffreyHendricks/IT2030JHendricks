using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FinalEventApplication.Models
{
    public class EndNotInPastAttribute : ValidationAttribute
    {


        public EndNotInPastAttribute(): base("{0} cannot be in the past!")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime ed = (DateTime)value;
            if(ed < DateTime.Now)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}