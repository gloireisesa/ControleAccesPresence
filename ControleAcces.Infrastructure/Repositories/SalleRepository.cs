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
    public class SalleRepository : ISalleRepository
    {
        private readonly ApplicationDbContext _context;

        public SalleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Salle salle)
        {
            await _context.Salles.AddAsync(salle);
            await _context.SaveChangesAsync();
        }

        public async Task<Salle> GetByIdAsync(int id)
        {
            return await _context.Salles.FindAsync(id);
        }

        public async Task UpdateAsync(Salle salle)
        {
            _context.Salles.Update(salle);
            await _context.SaveChangesAsync();
        }

        public Task AssignerASessionAsync(int salleId, int sessionId)
        {
            throw new NotImplementedException();
        }

        public Task DesassignerDeSessionAsync(int salleId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Salle>> GetAllAsync()
        {
            return await _context.Salles.ToListAsync();
        }

        public Task GetByIdAsync(Salle salleId)
        {
            throw new NotImplementedException();
        }
    }
}
