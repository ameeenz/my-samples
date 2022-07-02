using Driving.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Driving.Tools
{
    public class CustomAgeValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ApplicationForm = (ApplicationFormEntity)validationContext.ObjectInstance;
            int Age = DateTime.Now.Year - ApplicationForm.BirthDate.Year;
            if (Age>18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Your Age is not acceptable");
            }
        }
    }
}