using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface ISalleRepository
    {
        //Task<Salle> GetByIdAsync(Guid id);
        //Task<IEnumerable<Salle>> GetAllAsync();
        Task AddAsync(Salle salle);
        Task UpdateAsync(Salle salle);
        Task GetByIdAsync(Salle salleId);
        Task<List<Salle>> GetAllAsync();
        Task<Salle> GetByIdAsync(int id);
        Task AssignerASessionAsync(int salleId, int sessionId);
        Task DesassignerDeSessionAsync(int salleId);
        Task<List<Salle>> GetSallesParSessionAsync(int sessionId);
    }
}
