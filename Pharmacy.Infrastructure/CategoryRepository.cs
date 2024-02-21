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
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
