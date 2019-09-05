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
            IList<Employment> temp = model.Employments;
            foreach (var e1 in temp)
            {
                foreach (var e2 in temp)
                {
                    if (e1 != e2)
                    {
                        if (e1.HireDate < e2.LeaveDate && e2.HireDate < e1.LeaveDate || e1.LeaveDate == null && e2.LeaveDate == null)
                        {
                            return new ValidationResult("Dates overlap");
                        }
                    }
                    
                }
            }
            return ValidationResult.Success;
        }
    }
}
