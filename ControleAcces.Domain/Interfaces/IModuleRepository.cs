using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IModuleRepository
    {
        Task<Module> GetByIdAsync(int id);
        //Task<IEnumerable<Module>> GetAllAsync();
        Task AddAsync(Module module);
        Task UpdateAsync(Module module);
        Task<List<Domain.Entities.Module>> GetAllAsync();
        //Task<Domain.Entities.Module> GetByIdAsync(Guid id);
        //Task AddAsync(Domain.Entities.Module module);
        //Task UpdateAsync(Domain.Entities.Module module);
        Task DeleteAsync(Module module);
    }
}
