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
    public class AccesExamenService
    {
        private readonly IAccesExamenRepository _accesExamenRepository;

        public AccesExamenService(IAccesExamenRepository accesExamenRepository)
        {
            _accesExamenRepository = accesExamenRepository;
        }

        public async Task<bool> VerifierAccesAsync(int etudiantId)
        {
            return await _accesExamenRepository.VerifierAccesAsync(etudiantId);
        }
        public async Task EnregistrerAccesAsync(AccesExamenDto dto)
        {
            var acces = new AccesExamen
            {
                EtudiantId = dto.EtudiantId,
                SalleId = dto.SalleId,
                ModuleId = dto.ModuleId,
                HoraireExamenId = dto.HoraireExamenId
            };

            await _accesExamenRepository.AddAsync(acces);
        }
    }
}
