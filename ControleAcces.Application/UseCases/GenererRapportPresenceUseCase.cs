using ControleAcces.Application.DTOs;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Shared.DTOs;
using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.UseCases
{
    public class GenererRapportPresenceUseCase
    {
        private readonly IJournalPresenceRepository _journalPresenceRepository;
        private readonly IEtudiantRepository _etudiantRepository;
        private readonly ISalleRepository _salleRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IPromotionRepository _promotionRepository;

        public GenererRapportPresenceUseCase(
            IJournalPresenceRepository journalPresenceRepository,
            IEtudiantRepository etudiantRepository,
            ISalleRepository salleRepository,
            ISessionRepository sessionRepository,
            IPromotionRepository promotionRepository)
        {
            _journalPresenceRepository = journalPresenceRepository;
            _etudiantRepository = etudiantRepository;
            _salleRepository = salleRepository;
            _sessionRepository = sessionRepository;
            _promotionRepository = promotionRepository;
        }

        // --- Rapport principal ---
        public async Task<List<JournalPresenceDTO>> GenererRapportAsync(
            int? sessionId,
            int? salleId,
            string? matricule,
            int? promotionId,
            DateTime? date)
        {
            var journaux = await _journalPresenceRepository.GetAllAsync();
            var etudiants = await _etudiantRepository.GetAllAsync();

            // --- Filtres ---
            if (sessionId.HasValue)
                journaux = journaux.Where(j => j.SessionId == sessionId.Value).ToList();

            if (salleId.HasValue)
                journaux = journaux.Where(j => j.SalleId == salleId.Value).ToList();

            if (!string.IsNullOrWhiteSpace(matricule))
            {
                var etudiantIds = etudiants
                    .Where(e => e.Matricule.Equals(matricule, StringComparison.OrdinalIgnoreCase))
                    .Select(e => e.Id)
                    .ToList();

                journaux = journaux.Where(j => etudiantIds.Contains(j.EtudiantId)).ToList();
            }

            if (promotionId.HasValue)
            {
                etudiants = etudiants.Where(e => e.IdPromotion == promotionId.Value).ToList();
            }

            if (date.HasValue)
                journaux = journaux.Where(j => j.Date.Date == date.Value.Date).ToList();

            var result = new List<JournalPresenceDTO>();

            foreach (var etudiant in etudiants)
            {
                var journal = journaux.FirstOrDefault(j => j.EtudiantId == etudiant.Id);
                var salle = journal != null ? await _salleRepository.GetByIdAsync(journal.SalleId) : null;
                var session = journal != null ? await _sessionRepository.GetByIdAsync(journal.SessionId) : null;

                result.Add(new JournalPresenceDTO
                {
                    EtudiantId = etudiant.Id,
                    Matricule = etudiant.Matricule ?? "",
                    NomComplet = $"{etudiant.Nom} {etudiant.PostNom} {etudiant.Prenom}",
                    SalleId = journal?.SalleId ?? 0,
                    SalleNom = salle?.NomSalle ?? "",
                    SessionId = journal?.SessionId ?? 0,
                    SessionNom = session?.Nom ?? "",
                    Date = journal?.Date ?? DateTime.MinValue,
                    HeureEntree = journal?.HeureEntree,
                    HeureSortie = journal?.HeureSortie,
                    Statut = journal?.Statut ?? "Absent"
                });
            }

            return result;
        }

        // --- Rapport filtré par promotion ---
        public async Task<List<JournalPresenceDTO>> GenererRapportParPromotionAsync(
            int promotionId,
            int? sessionId = null,
            int? salleId = null,
            DateTime? date = null)
        {
            // Appelle le rapport principal en passant le promotionId
            return await GenererRapportAsync(sessionId, salleId, null, promotionId, date);
        }

        // --- Statistiques ---
        public async Task<StatistiquesDTO> GenererStatistiquesAsync(
            int? sessionId,
            int? salleId,
            int? promotionId,
            DateTime? date)
        {
            if (promotionId.HasValue)
                return null; // Pas de stats pour promotion

            var rapport = await GenererRapportAsync(sessionId, salleId, null, null, date);

            var total = rapport.Count;
            var presents = rapport.Count(r => r.Statut == "Présent");

            return new StatistiquesDTO
            {
                TotalEtudiants = total,
                NombrePresent = presents,
                TauxPresence = total > 0 ? (decimal)presents * 100 / total : 0
            };
        }

        // --- Liste DTO Promotions pour filtre ---
        public async Task<List<PromotionDTO>> GetAllPromotionsAsync()
        {
            var promos = await _promotionRepository.GetAllAsync();
            return promos.Select(p => new PromotionDTO
            {
                Id = p.Id,
                Nom = p.Nom
            }).ToList();
        }

        // --- Liste DTO Salles pour filtre ---
        public async Task<List<SalleDTO>> GetAllSallesAsync()
        {
            var salles = await _salleRepository.GetAllAsync();
            return salles.Select(s => new SalleDTO
            {
                Id = s.Id,
                NomSalle = s.NomSalle
            }).ToList();
        }

        // --- Liste Sessions pour filtre ---
        public async Task<List<Session>> GetAllSessionsAsync()
        {
            return (await _sessionRepository.GetAllAsync()).ToList();
        }
    }
}
