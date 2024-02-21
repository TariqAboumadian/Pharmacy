using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class MedicineExpDate
    {
        public int Id { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = default!;
    }
}
