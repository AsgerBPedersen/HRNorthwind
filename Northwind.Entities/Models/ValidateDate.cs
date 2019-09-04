using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Entities.Models
{
    class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Employment model = (Employment)validationContext.ObjectInstance;
            if (model.HireDate > model.LeaveDate)
            {
                return new ValidationResult("Hire date can't be set before leave date");
            } else if (model.HireDate > DateTime.Now)
            {
                return new ValidationResult("Hire date can't be in the future");
            }
            return ValidationResult.Success;
        }
    }
}
