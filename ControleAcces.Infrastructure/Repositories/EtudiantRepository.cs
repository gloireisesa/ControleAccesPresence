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
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly ApplicationDbContext _context;

        public EtudiantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Etudiant etudiant)
        {
            await _context.Etudiants.AddAsync(etudiant);
            await _context.SaveChangesAsync();
        }

        public async Task<Etudiant> GetByIdAsync(int id)
        {
            return await _context.Etudiants.FindAsync(id);
        }

        public async Task<Etudiant?> GetByMatriculeAsync(string matricule)
        {
            if (string.IsNullOrWhiteSpace(matricule)) return null;

            var normalized = matricule.Trim().ToUpper();

            return await _context.Etudiants
                .Include(e => e.Promotion)
                .FirstOrDefaultAsync(e => e.Matricule.ToUpper() == normalized);
        }

        public async Task<IEnumerable<Etudiant>> GetAllAsync()
        {
            return await _context.Etudiants.ToListAsync();
        }

        public async Task UpdateAsync(Etudiant etudiant)
        {
            _context.Etudiants.Update(etudiant);
            await _context.SaveChangesAsync();
        }

      

        public Task<Etudiant> GetByCodeIdentificationAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
