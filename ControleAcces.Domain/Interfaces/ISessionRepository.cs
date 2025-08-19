using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ControleAcces.Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task AddAsync(Session session);
        Task<Session> GetByIdAsync(int sessionId);
        Task<List<Session>> GetAllAsync();
        Task UpdateAsync(Session session);
        Task DeleteAsync(int id);
        Task<Session?> GetByIdAsync(int? sessionId);
        //Task<IEnumerable<object>> GetEtudiantsParSessionAsync(int sessionId);
        //Task<string> GetByIdAsync(int? sessionId);

        //Task<List<Session>> GetAllAsync();
        //Task<Session> GetByIdAsync(Guid id);
        //Task AddAsync(Session session);

    }
    }
