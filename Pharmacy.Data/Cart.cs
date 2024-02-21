using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set;}
        public virtual ICollection<CarItems> CarItems { get; set; } = new HashSet<CarItems>();
    }
}
