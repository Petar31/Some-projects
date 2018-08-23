using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ProductionYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Production date is not in given range");
            }
           // DateTime dateTime = (DateTime)value;
            if ((int)value <= DateTime.Now.Year && (int)value > DateTime.Now.AddYears(-100).Year)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Production date is not in given range");
            }

        }
    }
}