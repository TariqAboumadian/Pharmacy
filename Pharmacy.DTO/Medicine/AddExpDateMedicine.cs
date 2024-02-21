using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DTO.Medicine
{
    public class AddExpDateMedicine
    {
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int MedicineId { get; set; }
    }
}
