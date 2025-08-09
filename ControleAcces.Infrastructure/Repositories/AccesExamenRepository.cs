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
    public class AccesExamenRepository : IAccesExamenRepository
    {
        private readonly ApplicationDbContext _context;

        public AccesExamenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AccesExamen accesExamen)
        {
            await _context.AccesExamens.AddAsync(accesExamen);
            await _context.SaveChangesAsync();
        }

        public async Task<AccesExamen> GetByIdAsync(int id)
        {
            return await _context.AccesExamens
                .Include(a => a.Etudiant)
                .Include(a => a.Salle)
                .Include(a => a.Module)
                .Include(a => a.HoraireExamen)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AccesExamen>> GetAllByEtudiantAsync(int etudiantId)
        {
            return await _context.AccesExamens
                .Where(a => a.EtudiantId == etudiantId)
                .Include(a => a.Salle)
                .Include(a => a.Module)
                .Include(a => a.HoraireExamen)
                .ToListAsync();
        }

        public Task<bool> VerifierAccesAsync(int etudiantId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasAccessAsync(int id, string salleId, DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
