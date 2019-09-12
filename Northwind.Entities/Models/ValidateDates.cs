using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Entities.Models
{
    public class ValidateDates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Employee model = (Employee)validationContext.ObjectInstance;
            var res = Employee.EmploymentsValidation(model.Employments);
            if (!res.isValid)
            {
                return new ValidationResult(res.message);
            }
            return ValidationResult.Success;
        }
    }
}
