using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class SessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> GetAllSessionsAsync()
        {
            return await _sessionRepository.GetAllAsync();
        }

        public async Task<Session?> GetSessionByIdAsync(int sessionId)
        {
            return await _sessionRepository.GetByIdAsync(sessionId);
        }

        public async Task<bool> CreerSessionAsync(string nom, DateTime dateDebut, DateTime dateFin, string anneeAcademique)
        {
            var session = new Session
            {
                //Id = int.NewGuid(),
                Nom = nom,
                DateDebut = dateDebut,
                DateFin = dateFin,
                AnneeAcademique = anneeAcademique
            };

            await _sessionRepository.AddAsync(session);
            return true;
        }
    }
}
