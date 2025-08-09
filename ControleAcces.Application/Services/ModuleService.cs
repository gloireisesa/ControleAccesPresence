using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class ModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            return await _moduleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await _moduleRepository.GetAllAsync();
        }

        public async Task AjouterModuleAsync(Module module)
        {
            await _moduleRepository.AddAsync(module);
        }

        public async Task ModifierModuleAsync(Module module)
        {
            await _moduleRepository.UpdateAsync(module);
        }
    }
}