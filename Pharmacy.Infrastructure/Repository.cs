using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Contracts;
using Pharmacy.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure
{
    public class Repository<Tentity, Tid> : IRepository<Tentity, Tid> where Tentity: class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Tentity> _dbset;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbset=_context.Set<Tentity>();
        }
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            var res = await _dbset.AddAsync(entity);
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(Tentity entity)
        {
            var res = await Task.FromResult(_dbset.Remove(entity));
            return res != null ? true : false;
        }

        public Task<List<Tentity>> GetAllAsync()
        {
            return Task.FromResult(_dbset.ToList());
        }

        public async Task<Tentity> GetByIdAsync(Tid id)
        {
            return await _dbset.FindAsync(id) ?? default!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Tentity entity)
        {
            var res =await Task.FromResult(_dbset.Update(entity));
            return res!=null? true : false;
        }
    }
}
