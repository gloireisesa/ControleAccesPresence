using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{   
        public interface IJournalPresenceRepository
        {
            Task<List<JournalPresence>> GetAllAsync();
            Task<JournalPresence> GetByIdAsync(int id);
            Task AjouterAsync(JournalPresence presence);
            Task SupprimerAsync(int id);
            Task<List<JournalPresence>> GetBySessionIdAsync(int sessionId);
        Task AddAsync(JournalPresence journal);
        Task MarquerSortieAsync(int etudiantId);
        Task UpdateAsync(JournalPresence journal);
        Task<JournalPresence> GetOuvertByEtudiantIdAsync(int etudiantId);
    }
    }
