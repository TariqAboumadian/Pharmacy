using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class CarItems
    {
        public int Id { get; set; }
        public decimal SubPrice { get; set; }
        [ForeignKey(nameof(CarItems.Cart))]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; } = default!;

        public virtual ICollection<CartItemMedicine> CartItemMedicines { get; set; }=
            new HashSet<CartItemMedicine>();
    }
}
