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
        public async Task GenererAccesExamenPourSessionAsync(int sessionId)
        {
            // Récupérer tous les horaires de cette session
            var horaires = await _context.HoraireExamens
                .Where(h => h.SessionId == sessionId)
                .ToListAsync();

            if (!horaires.Any())
                throw new InvalidOperationException($"Aucun horaire trouvé pour la session {sessionId}");

            // Récupérer tous les modules de cette session
            var modules = await _context.Modules
                .Where(m => m.SessionId == sessionId)
                .ToListAsync();

            // Récupérer tous les étudiants de cette session
            var etudiants = await _context.Etudiants
                .Where(e => e.SessionId == sessionId)
                .ToListAsync();

            var accesList = new List<AccesExamen>();

            foreach (var etudiant in etudiants)
            {
                foreach (var module in modules)
                {
                    // Trouver l'horaire correspondant au module et à la salle
                    var horaire = horaires.FirstOrDefault(h => h.SalleId == module.SalleId);

                    if (horaire != null)
                    {
                        accesList.Add(new AccesExamen
                        {
                            EtudiantId = etudiant.Id,
                            ModuleId = module.Id,
                            SalleId = module.SalleId.Value,
                            HoraireExamenId = horaire.Id
                        });
                    }
                }
            }

            if (accesList.Any())
            {
                await _context.AccesExamens.AddRangeAsync(accesList);
                await _context.SaveChangesAsync();
            }
        }

    }
}
