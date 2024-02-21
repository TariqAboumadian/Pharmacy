using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class CartItemMedicine
    {
        [ForeignKey(nameof(CartItemMedicine.Medicine))]
        public int MedicineId { get; set;}
        public virtual Medicine Medicine { get; set; } = default!;
        [ForeignKey(nameof(CartItemMedicine.CarItems))]
        public int CartItemId { get; set; }
        public virtual CarItems CarItems { get; set; }= default!;
        public int Quantity { get; set; }
        public decimal price { get; set; }
    }
}
