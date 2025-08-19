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
    public class HoraireExamenRepository : IHoraireExamenRepository
    {
        private readonly ApplicationDbContext _context;

        public HoraireExamenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HoraireExamen horaire)
        {
            await _context.HoraireExamens.AddAsync(horaire);
            await _context.SaveChangesAsync();
        }

        public async Task<HoraireExamen> GetByIdAsync(int id)
        {
            return await _context.HoraireExamens.FindAsync(id);
        }

        public async Task<IEnumerable<HoraireExamen>> GetAllAsync()
        {
            return await _context.HoraireExamens.ToListAsync();
        }

        // --- Mise à jour uniquement de SessionId et ModuleId ---
        public async Task UpdateAsync(HoraireExamen horaireExamen)
        {
            var existing = await _context.HoraireExamens.FindAsync(horaireExamen.Id);
            if (existing != null)
            {
                existing.SessionId = horaireExamen.SessionId;
                existing.ModuleId = horaireExamen.ModuleId;

                _context.HoraireExamens.Update(existing);
                await _context.SaveChangesAsync();
            }
        }

        // --- Récupérer tous les horaires par ModuleId ---
        public async Task<List<HoraireExamen>> GetByModuleIdAsync(int moduleId)
        {
            return await _context.HoraireExamens
                                 .Where(h => h.ModuleId == moduleId)
                                 .ToListAsync();
        }

        // --- Supprimer un horaire ---
        public async Task DeleteAsync(HoraireExamen horaire)
        {
            _context.HoraireExamens.Remove(horaire);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateByModuleAndSessionAsync(int moduleId, int sessionId, int salleId)
        {
            var horaires = await _context.HoraireExamens
                .Where(h => h.SalleId == salleId)
                .ToListAsync();

            if (horaires.Any())
            {
                foreach (var horaire in horaires)
                {
                    horaire.ModuleId = moduleId;
                    horaire.SessionId = sessionId;
                }

                _context.HoraireExamens.UpdateRange(horaires);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Aucun horaire trouvé pour la salle {salleId}.");
            }
        }
    }
}
