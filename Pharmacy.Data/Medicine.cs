using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;

        [ForeignKey(nameof(Medicine.Company))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; } = default!;
        [ForeignKey(nameof(Medicine.Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
        public virtual ICollection<CartItemMedicine> CartItemMedicines { get; set; }=
            new HashSet<CartItemMedicine>();
        public virtual ICollection<MedicineExpDate> MedicineExpDates { get; set; } =
            new HashSet<MedicineExpDate>();
    }
}
