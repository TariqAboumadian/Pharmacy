using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DTO.Validation
{
    public class ValidateDateAttribute : ValidationAttribute {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                // Use dateValue for validation logic
                // For example, you might compare it with DateTime.Now
                if (dateValue < DateTime.Now)
                {
                    // Validation failed
                    return new ValidationResult("EXP Date Must be in the future.");
                }
            }
            else
            {
                // Validation failed if value is not a DateTime
                return new ValidationResult("Value must be a DateTime.");
            }

            // Validation succeeded
            return ValidationResult.Success;
        }

    }
}
