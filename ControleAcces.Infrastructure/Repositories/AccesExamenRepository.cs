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

        // Ajoute un accès en base
        public async Task AddAsync(AccesExamen accesExamen)
        {
            await _context.AccesExamens.AddAsync(accesExamen);
            await _context.SaveChangesAsync();
        }

        // Récupère un accès par Id
        public async Task<AccesExamen> GetByIdAsync(int id)
        {
            return await _context.AccesExamens
                .Include(a => a.Etudiant)
                .Include(a => a.Salle)
                .Include(a => a.Module)
                .Include(a => a.HoraireExamen)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Récupère tous les accès pour un étudiant
        public async Task<IEnumerable<AccesExamen>> GetAllByEtudiantAsync(int etudiantId)
        {
            return await _context.AccesExamens
                .Where(a => a.EtudiantId == etudiantId)
                .Include(a => a.Salle)
                .Include(a => a.Module)
                .Include(a => a.HoraireExamen)
                .ToListAsync();
        }

        // Vérifie si un étudiant a déjà un accès
        public async Task<bool> VerifierAccesAsync(int etudiantId)
        {
            return await _context.AccesExamens
                .AnyAsync(a => a.EtudiantId == etudiantId);
        }

        // Vérifie si un étudiant a accès à une salle pour un horaire donné
        public async Task<bool> HasAccessAsync(int etudiantId, int salleId, int horaireId)
        {
            return await _context.AccesExamens
                .AnyAsync(a => a.EtudiantId == etudiantId
                            && a.SalleId == salleId
                            && a.HoraireExamenId == horaireId);
        }
    }
}
