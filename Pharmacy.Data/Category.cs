using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public string Image { get; set; } = string.Empty;
        public virtual ICollection<Medicine> Medicines { get; set; }=
            new HashSet<Medicine>();
    }
}
