using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class Order
    {
        public int Id {  get; set; }
        public string OrederAdress { get; set; } = string.Empty;
        public DateTime DeliveryDate { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; } = default!;
    }
}
