using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class HoraireExamenService
    {
        private readonly IHoraireExamenRepository _horaireExamenRepository;

        public HoraireExamenService(IHoraireExamenRepository horaireExamenRepository)
        {
            _horaireExamenRepository = horaireExamenRepository;
        }

        public async Task<HoraireExamen> GetByIdAsync(int id)
        {
            return await _horaireExamenRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<HoraireExamen>> GetAllAsync()
        {
            return await _horaireExamenRepository.GetAllAsync();
        }

        public async Task AjouterHoraireExamenAsync(HoraireExamen horaireExamen)
        {
            await _horaireExamenRepository.AddAsync(horaireExamen);
        }

        public async Task ModifierHoraireExamenAsync(HoraireExamen horaireExamen)
        {
            await _horaireExamenRepository.UpdateAsync(horaireExamen);
        }
    }
}
