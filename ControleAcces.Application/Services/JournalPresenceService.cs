using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class JournalPresenceService
    {
        private readonly IJournalPresenceRepository _journalPresenceRepository;

        public JournalPresenceService(IJournalPresenceRepository journalPresenceRepository)
        {
            _journalPresenceRepository = journalPresenceRepository;
        }

        public async Task AjouterPresenceAsync(JournalPresence journal)
        {
            await _journalPresenceRepository.AddAsync(journal);
        }

        public async Task MarquerSortieAsync(int etudiantId)
        {
            await _journalPresenceRepository.MarquerSortieAsync(etudiantId);
        }
    }
}
