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
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ApplicationDbContext _context;
        public UtilisateurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Utilisateur?> GetByEmailAsync(string email)
        {
            return await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
