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
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
