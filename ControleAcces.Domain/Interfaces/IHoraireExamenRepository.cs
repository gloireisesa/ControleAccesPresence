using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IHoraireExamenRepository
    {
        Task<HoraireExamen> GetByIdAsync(int id);
        Task<IEnumerable<HoraireExamen>> GetAllAsync();
        Task AddAsync(HoraireExamen horaire);
        Task UpdateAsync(HoraireExamen horaireExamen);
        Task<List<HoraireExamen>> GetByModuleIdAsync(int moduleId);
        Task DeleteAsync(HoraireExamen horaire);
        Task UpdateByModuleAndSessionAsync(int moduleId, int sessionId, int salleId);
        //Task UpdateAsync(HoraireExamen horaire);
    }
}
