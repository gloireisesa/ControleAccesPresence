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
            return await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task UpdateAsync(Module module)
        {
            // Vérifie si l'entité est détachée
            var tracked = await _context.Modules.FindAsync(module.Id);
            if (tracked == null)
            {
                // L'entité n’existe pas → rien à faire
                return;
            }

            // Met à jour les propriétés manuellement pour éviter les soucis d’attachement
            _context.Entry(tracked).CurrentValues.SetValues(module);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Module module)
        {
            var tracked = await _context.Modules.FindAsync(module.Id);
            if (tracked != null)
            {
                _context.Modules.Remove(tracked);
                await _context.SaveChangesAsync();
            }
        }
    }
}
