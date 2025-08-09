using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class EtudiantService
    {
        private readonly IEtudiantRepository _etudiantRepository;

        public EtudiantService(IEtudiantRepository etudiantRepository)
        {
            _etudiantRepository = etudiantRepository;
        }

        public async Task<Etudiant> GetByIdAsync(int id)
        {
            return await _etudiantRepository.GetByIdAsync(id);
        }

        public async Task<Etudiant> GetByMatriculeAsync(string matricule)
        {
            return await _etudiantRepository.GetByMatriculeAsync(matricule);
        }

        public async Task<IEnumerable<Etudiant>> GetAllAsync()
        {
            return await _etudiantRepository.GetAllAsync();
        }

        public async Task AjouterEtudiantAsync(Etudiant etudiant)
        {
            await _etudiantRepository.AddAsync(etudiant);
        }

        public async Task ModifierEtudiantAsync(Etudiant etudiant)
        {
            await _etudiantRepository.UpdateAsync(etudiant);
        }
    }
}
