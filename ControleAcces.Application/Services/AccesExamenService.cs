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
    }
}
