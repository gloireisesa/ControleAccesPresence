using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Module module)
        {
            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            return await _context.Modules.FindAsync(id);
        }

        public async Task UpdateAsync(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
        }

        async Task<List<Module>> IModuleRepository.GetAllAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public Task DeleteAsync(Module module)
        {
            throw new NotImplementedException();
        }

        //public Task<IEnumerable<Module>> GetAllAsync()
        //{
        //    return await _context.Modules.ToListAsync();
        //}
    }
}
