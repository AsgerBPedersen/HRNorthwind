using Northwind.WebServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Entities.Models
{
    class ValidateProfanity : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Employee model = (Employee)validationContext.ObjectInstance;
            var res = EmployeeValidator.ValidateProfanity(model.Notes);
            if (!res.isValid)
            {
                string s = "";
                for (int i = 0; i < res.errors.Count; i++)
                {
                    s += res.errors[i];
                    if (i != res.errors.Count - 1)
                    {
                        s += ", ";
                    } else
                    {
                        s += " ";
                    }
                     
                }
                return new ValidationResult($"Disse ord er ikke tilladt: {s}");
            }
            return ValidationResult.Success;
        }
    }
}
