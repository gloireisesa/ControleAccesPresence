using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.UseCases
{
    public class PointerPresenceUseCase
    {
        private readonly IJournalPresenceRepository _journalPresenceRepository;
        private readonly IIdentifiantRepository _identifiantRepository;
        private readonly IHardwareService _hardwareService;

        public PointerPresenceUseCase(
            IJournalPresenceRepository journalPresenceRepository,
            IIdentifiantRepository identifiantRepository,
            IHardwareService hardwareService)
        {
            _journalPresenceRepository = journalPresenceRepository;
            _identifiantRepository = identifiantRepository;
            _hardwareService = hardwareService;
        }

        public async Task<bool> PointerAsync()
        {
            var carteCode = await _hardwareService.ScannerCarteRFIDAsync();
            var empreinteCode = await _hardwareService.ScannerEmpreinteDigitaleAsync();

            if (string.IsNullOrEmpty(carteCode) || string.IsNullOrEmpty(empreinteCode))
                return false;

            var identifiant = await _identifiantRepository.GetByCodesAsync(carteCode, empreinteCode);
            if (identifiant == null) return false;

            var journal = await _journalPresenceRepository.GetOuvertByEtudiantIdAsync(identifiant.Id);

            if (journal == null)
            {
                // Entrée
                journal = new JournalPresence
                {
                    //Id = int.NewGuid(),
                    EtudiantId = identifiant.Id,
                    HeureEntree = DateTime.Now
                };
                await _journalPresenceRepository.AddAsync(journal);
            }
            else
            {
                // Sortie
                journal.HeureSortie = DateTime.Now;
                await _journalPresenceRepository.UpdateAsync(journal);
            }

            return true;
        }
    }

}
