using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Contracts
{
    public interface IRepository<Tentity,Tid>
    {
        public Task<Tentity> CreateAsync(Tentity entity);
        public Task<Tentity> GetByIdAsync(Tid id);
        public Task<List<Tentity>> GetAllAsync();
        public Task<bool> UpdateAsync(Tentity entity);
        public Task<bool> DeleteAsync(Tentity entity);
        public Task<int> SaveChangesAsync();
    }
}
