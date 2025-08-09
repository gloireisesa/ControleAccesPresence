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
    public class IdentifiantRepository : IIdentifiantRepository
    {
        private readonly ApplicationDbContext _context;

        public IdentifiantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Identifiant identifiant)
        {
            await _context.Identifiants.AddAsync(identifiant);
            await _context.SaveChangesAsync();
        }
        public Task<Identifiant?> GetByEtudiantIdAsync(int etudiantId)
        {
            throw new NotImplementedException();
        }

        public async Task<Identifiant> GetByIdAsync(int id)
        {
            return await _context.Identifiants.FindAsync(id);
        }

        public async Task<Identifiant> GetByValeurAsync(string valeur)
        {
            return await _context.Identifiants.FirstOrDefaultAsync(i => i.Valeur == valeur);
        }

       
        public async Task<Identifiant?> GetByCodesAsync(string carteCode, string empreinteCode)
        {
            return await _context.Identifiants
                .FirstOrDefaultAsync(i => i.CarteCode == carteCode && i.EmpreinteCode == empreinteCode);
        }

        public Task UpdateAsync(Identifiant identifiant)
        {
            throw new NotImplementedException();
        }

        public Task HasCodesAsync(string carteCode, string empreinteCode)
        {
            throw new NotImplementedException();
        }

        public Task<Identifiant> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
