using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DTO.Medicine
{
    public class AddMedicineDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public IFormFile Image { get; set; } = default!;
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
    }
}
