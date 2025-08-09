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

        public GenererRapportPresenceUseCase(
            IJournalPresenceRepository journalPresenceRepository,
            IEtudiantRepository etudiantRepository,
            ISalleRepository salleRepository,
            ISessionRepository sessionRepository)
        {
            _journalPresenceRepository = journalPresenceRepository;
            _etudiantRepository = etudiantRepository;
            _salleRepository = salleRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<List<JournalPresenceDTO>> GenererRapportAsync(string? sessionId, string? salleId, string? matricule, DateTime? date)
        {
            var journaux = await _journalPresenceRepository.GetAllAsync();

            // Appliquer les filtres
            if (!string.IsNullOrWhiteSpace(sessionId) && int.TryParse(sessionId, out var sessionInt))
                journaux = journaux.Where(j => j.SessionId == sessionInt).ToList();

            if (!string.IsNullOrWhiteSpace(salleId) && int.TryParse(salleId, out var salleInt))
                journaux = journaux.Where(j => j.SalleId == salleInt).ToList();

            if (!string.IsNullOrWhiteSpace(matricule))
            {
                var etudiants = await _etudiantRepository.GetAllAsync();
                var etudiantIds = etudiants
                    .Where(e => e.Matricule.Equals(matricule, StringComparison.OrdinalIgnoreCase))
                    .Select(e => e.Id)
                    .ToList();

                journaux = journaux.Where(j => etudiantIds.Contains(j.EtudiantId)).ToList();
            }

            if (date.HasValue)
                journaux = journaux.Where(j => j.Date.Date == date.Value.Date).ToList();

            var result = new List<JournalPresenceDTO>();

            foreach (var journal in journaux)
            {
                var etudiant = await _etudiantRepository.GetByIdAsync(journal.EtudiantId);
                var salle = await _salleRepository.GetByIdAsync(journal.SalleId);
                var session = await _sessionRepository.GetByIdAsync(journal.SessionId);

                result.Add(new JournalPresenceDTO
                {
                    EtudiantId = journal.EtudiantId,
                    Matricule = etudiant.Matricule,
                    NomComplet = $"{etudiant.Nom} {etudiant.PostNom} {etudiant.Prenom}",
                    SalleId = journal.SalleId,
                    SalleNom = salle.NomSalle,
                    SessionId = journal.SessionId,
                    SessionNom = session.Nom,
                    Date = journal.Date,
                    HeureEntree = journal.HeureEntree,
                    HeureSortie = journal.HeureSortie,
                    Statut = journal.Statut
                });
            }

            return result;
        }

        public async Task<List<Session>> GetAllSessionsAsync()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<List<SalleDTO>> GetAllSallesAsync()
        {
            var salles = await _salleRepository.GetAllAsync();
            return salles.Select(s => new SalleDTO
            {
                Id = s.Id,
                NomSalle = s.NomSalle,
                Capacite = s.Capacite,
                Session = s.SessionNom
            }).ToList();
        }
    }

}
