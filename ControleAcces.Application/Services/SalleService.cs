using ControleAcces.Application.DTOs;
using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class SalleService
    {
        private readonly ISalleRepository _salleRepository;

        public SalleService(ISalleRepository salleRepository)
        {
            _salleRepository = salleRepository;
        }

        public async Task<Salle> GetByIdAsync(int id)
        {
            return await _salleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Salle>> GetAllAsync()
        {
            return await _salleRepository.GetAllAsync();
        }

        public async Task AjouterSalleAsync(Salle salle)
        {
            await _salleRepository.AddAsync(salle);
        }
        public async Task<List<SalleDTO>> GetAllSallesAsync()
        {
            var salles = await _salleRepository.GetAllAsync();
            return salles.Select(s => new SalleDTO
            {
                Id = s.Id,
                NomSalle = s.NomSalle,
                Capacite = s.Capacite,
                SessionId = s.SessionId,
                SessionNom = s.SessionNom,
            }).ToList();
        }
        public async Task AssignerSalleASessionAsync(int salleId, int sessionId)
        {
            await _salleRepository.AssignerASessionAsync(salleId, sessionId);
        }

        public async Task DesassignerSalleAsync(int salleId)
        {
            await _salleRepository.DesassignerDeSessionAsync(salleId);
        }

        public async Task ModifierSalleAsync(Salle salle)
        {
            await _salleRepository.UpdateAsync(salle);
        }
    }
}