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
    public class FileSizeAttribute:ValidationAttribute
    {
        private readonly int maxsize;
        public FileSizeAttribute(int _maxsize)
        {
            maxsize = _maxsize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file != null)
            {
                if(file.Length> maxsize)
                {
                    return new ValidationResult($"Max Size Must Be Less Than {FileSetings.MaxFilleSizeInBytes}MB");
                }
            }
            return ValidationResult.Success;
        }
    }
}
