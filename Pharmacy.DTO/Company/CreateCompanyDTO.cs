using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DTO.Company
{
    public class CreateCompanyDTO
    {
        [MaxLength(100, ErrorMessage = "Name Length Must Be Less Than 100char")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = "Address Length Must Be Less Than 200char")]
        public string Address { get; set; } = string.Empty;
        [RegularExpression(@"^(012|015|010|011)[0-9]{8}$",ErrorMessage ="Enter Correct Phone Number")]
        public string Phone { get; set; } = string.Empty;
    }
}
