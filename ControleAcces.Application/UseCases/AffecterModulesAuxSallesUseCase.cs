using ControleAcces.Application.DTOs;
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

        public AffecterModulesAuxSallesUseCase(
            IModuleRepository moduleRepository,
            ISalleRepository salleRepository)
        {
            _moduleRepository = moduleRepository;
            _salleRepository = salleRepository;
        }

        // Récupère tous les modules avec le nom de la salle affectée
        public async Task<List<ModuleDTO>> GetAllModulesAsync()
        {
            var modules = await _moduleRepository.GetAllAsync();
            var salles = await _salleRepository.GetAllAsync();

            return modules.Select(m => new ModuleDTO
            {
                Id = m.Id,
                Nom = m.Nom,
                Session = m.Session,
                SalleAffectee = m.SalleId.HasValue
                    ? salles.FirstOrDefault(s => s.Id == m.SalleId.Value)?.NomSalle
                    : null
            }).ToList();
        }

        // Récupère toutes les salles
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

        // Ajouter un module
        public async Task<bool> AjouterModuleAsync(string nom, string session, int? salleId)
        {
            var module = new Domain.Entities.Module
            {
                Nom = nom,
                Session = session,
                SalleId = salleId
            };
            await _moduleRepository.AddAsync(module);
            return true;
        }

        // Modifier un module
        public async Task<bool> ModifierModuleAsync(int moduleId, string nom, string session, int? salleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            module.Nom = nom;
            module.Session = session;
            module.SalleId = salleId;

            await _moduleRepository.UpdateAsync(module);
            return true;
        }

        // Supprimer un module
        public async Task<bool> SupprimerModuleAsync(int moduleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            await _moduleRepository.DeleteAsync(module);
            return true;
        }

        // Désaffecter la salle d'un module
        public async Task<bool> DesaffecterSalleDuModuleAsync(int moduleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            module.SalleId = null;
            await _moduleRepository.UpdateAsync(module);
            return true;
        }
    }
}