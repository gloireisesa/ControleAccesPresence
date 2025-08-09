using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class IdentifiantService
    {
        private readonly IIdentifiantRepository _identifiantRepository;

        public IdentifiantService(IIdentifiantRepository identifiantRepository)
        {
            _identifiantRepository = identifiantRepository;
        }

        public async Task<Identifiant> GetByIdAsync(int id)
        {
            return await _identifiantRepository.GetByIdAsync(id);
        }

        public async Task AjouterIdentifiantAsync(Identifiant identifiant)
        {
            await _identifiantRepository.AddAsync(identifiant);
        }

        public async Task ModifierIdentifiantAsync(Identifiant identifiant)
        {
            await _identifiantRepository.UpdateAsync(identifiant);
        }
    }
}
