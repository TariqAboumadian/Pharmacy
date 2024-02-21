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
    public class MedicineExpDateRepository : Repository<MedicineExpDate, int>, IMedicineExpDateRepository
    {
        public MedicineExpDateRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
