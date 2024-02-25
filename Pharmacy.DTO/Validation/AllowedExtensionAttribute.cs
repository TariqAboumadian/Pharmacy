using Microsoft.AspNetCore.Http;
using Pharmacy.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DTO.Validation
{
    public class AllowedExtensionAttribute:ValidationAttribute
    {
        private readonly string allowedextensions;
        public AllowedExtensionAttribute(string _allowedextensions)
        {
            allowedextensions = _allowedextensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);
                var isalloed=allowedextensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase); 
                if(!isalloed)
                {
                    return new ValidationResult($"Only Allowed Extensions {allowedextensions}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
