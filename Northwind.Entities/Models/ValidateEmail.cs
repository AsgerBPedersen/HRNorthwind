using Northwind.Entities.Models;
using Northwind.WebServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Entities
{
    class ValidateEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Employee model = (Employee)validationContext.ObjectInstance;
            if (!EmployeeValidator.EmailValidation(model.Email))
            {
                return new ValidationResult("Ugyldig email");
            }
            return ValidationResult.Success;
        }
    }
}
