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

        public async Task<List<ModuleDTO>> GetAllModulesAsync()
        {
            var modules = await _moduleRepository.GetAllAsync();
            return modules.Select(m => new ModuleDTO
            {
                Id = m.Id,
                Nom = m.Nom,
                Session = m.Session,
                SalleAffectee = m.SalleNom
            }).ToList();
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

        public async Task<bool> AjouterModuleAsync(string nom, string session, int? salleId)
        {
            var module = new Domain.Entities.Module
            {
                //Id = int.NewGuid(),
                Nom = nom,
                Session = session,
                SalleId = salleId
            };
            await _moduleRepository.AddAsync(module);
            return true;
        }

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

        public async Task<bool> SupprimerModuleAsync(int moduleId)
        {
            var module = await _moduleRepository.GetByIdAsync(moduleId);
            if (module == null) return false;

            await _moduleRepository.DeleteAsync(module);
            return true;
        }

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