using Microsoft.AspNetCore.Http;
using Pharmacy.Application.Services;
using Pharmacy.DTO.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DTO.Category
{
    public class AddCategory
    {
        [MaxLength(100, ErrorMessage = "Name Length Must Be Less Than 100char")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500, ErrorMessage = "Description Length Must Be Less Than 500char")]
        public string Description { get; set; } = string.Empty;
        [AllowedExtension(FileSetings.allowedextensions)]
        [FileSize(FileSetings.MaxFilleSizeInBytes)]
        public IFormFile Image { get; set; } =default!;
    }
}
