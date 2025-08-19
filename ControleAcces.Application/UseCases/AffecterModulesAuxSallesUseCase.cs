using ControleAcces.Application.DTOs;
using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.UseCases
{
    public class AffecterModulesAuxSallesUseCase
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ISalleRepository _salleRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IHoraireExamenRepository _horaireExamenRepository;

        public AffecterModulesAuxSallesUseCase(
            IModuleRepository moduleRepository,
            ISalleRepository salleRepository,
            ISessionRepository sessionRepository,
            IHoraireExamenRepository horaireExamenRepository)
        {
            _moduleRepository = moduleRepository;
            _salleRepository = salleRepository;
            _sessionRepository = sessionRepository;
            _horaireExamenRepository = horaireExamenRepository;

        }

        // 🔹 Récupère tous les modules avec la salle et la session affectées
        public async Task<List<ModuleDTO>> GetAllModulesAsync()
        {
            var modules = await _moduleRepository.GetAllAsync();
            var salles = await _salleRepository.GetAllAsync();
            var sessions = await _sessionRepository.GetAllAsync();

            return modules.Select(m => new ModuleDTO
            {
                Id = m.Id,
                Nom = m.Nom,
                Session = m.SessionId.HasValue
                    ? sessions.FirstOrDefault(s => s.Id == m.SessionId.Value)?.Nom
                    : null,
                SalleAffectee = m.SalleId.HasValue
                    ? salles.FirstOrDefault(s => s.Id == m.SalleId.Value)?.NomSalle
                    : null
            }).ToList();
        }

        // 🔹 Récupère toutes les salles
        public async Task<List<SalleDTO>> GetAllSallesAsync()
        {
            var salles = await _salleRepository.GetAllAsync();
            return salles.Select(s => new SalleDTO
            {
                Id = s.Id,
                NomSalle = s.NomSalle,
                Capacite = s.Capacite,
                Session = s.SessionId.HasValue ? s.Session.Nom : null
            }).ToList();
        }

        // 🔹 Récupère toutes les sessions
        public async Task<List<SessionDTO>> GetAllSessionsAsync()
        {
            var sessions = await _sessionRepository.GetAllAsync();
            return sessions.Select(s => new SessionDTO
            {
                Id = s.Id,
                Nom = s.Nom,
                TotalEtudiants = s.TotalEtudiants
            }).ToList();
        }

        // 🔹 Ajouter un module
        public async Task<bool> AjouterModuleAsync(string nom, int? sessionId, int? salleId)
        {
            var module = new Module
            {
                Nom = nom,
                SessionId = sessionId,
                SalleId = salleId
            };
            await _moduleRepository.AddAsync(module);

            if (sessionId.HasValue && salleId.HasValue)
            {
                await MettreAJourSalleEtSessionAsync(module.Id, sessionId.Value, salleId.Value);
            }

            return true;
        }

        // 🔹 Modifier un module
        public async Task<bool> ModifierModuleAsync(int moduleId, string nom, int? sessionId, int? salleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            module.Nom = nom;
            module.SessionId = sessionId;
            module.SalleId = salleId;

            await _moduleRepository.UpdateAsync(module);

            if (sessionId.HasValue && salleId.HasValue)
            {
                await MettreAJourSalleEtSessionAsync(module.Id, sessionId.Value, salleId.Value);
            }

            return true;
        }

        // 🔹 Supprimer un module
        public async Task<bool> SupprimerModuleAsync(int moduleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            await _moduleRepository.DeleteAsync(module);

            // Pas de recalcul de TotalEtudiants lors de suppression
            // la somme reste basée sur toutes les salles affectées à la session

            return true;
        }

        // 🔹 Désaffecter la salle d'un module
        public async Task<bool> DesaffecterSalleDuModuleAsync(int moduleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            if (module.SalleId.HasValue && module.SessionId.HasValue)
            {
                // Retirer la salle du module mais garder le total étudiant intact
                var salle = await _salleRepository.GetByIdAsync(module.SalleId.Value);
                if (salle != null)
                {
                    salle.SessionId = null;
                    await _salleRepository.UpdateAsync(salle);
                }

                module.SalleId = null;
                await _moduleRepository.UpdateAsync(module);
            }

            return true;
        }

        // 🔹 Méthode interne pour mettre à jour Salle, Session et HoraireExamen
        private async Task MettreAJourSalleEtSessionAsync(int moduleId, int sessionId, int salleId)
        {
            var salle = await _salleRepository.GetByIdAsync(salleId);
            var session = await _sessionRepository.GetByIdAsync(sessionId);

            if (salle != null && session != null)
            {
                salle.SessionId = sessionId;
                await _salleRepository.UpdateAsync(salle);

                // ⚡ Recalculer le total des étudiants pour la session
                var sallesDeLaSession = await _salleRepository.GetSallesParSessionAsync(sessionId);
                session.TotalEtudiants = sallesDeLaSession.Sum(s => s.Capacite);
                await _sessionRepository.UpdateAsync(session);

                // 🔹 Mettre à jour ou créer l'horaire d'examen
                await _horaireExamenRepository.UpdateByModuleAndSessionAsync(moduleId, sessionId, salleId);
            }

        }
    }
}
