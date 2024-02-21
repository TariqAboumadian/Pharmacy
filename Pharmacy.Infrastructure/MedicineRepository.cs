using Pharmacy.Application.Contracts;
using Pharmacy.Context;
using Pharmacy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure
{
    public class MedicineRepository : Repository<Medicine, int>, IMedicineRepository
    {
        public MedicineRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
