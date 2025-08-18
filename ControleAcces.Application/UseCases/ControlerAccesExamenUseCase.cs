using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Domain.ValueObjects;
using ControleAcces.Shared.DTOs;
using ControleAcces.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.UseCases
{
    public class ControlerAccesExamenUseCase
    {
        private readonly IIdentifiantRepository _identifiantRepository;
        private readonly IAccesExamenRepository _accesExamenRepository;
        private readonly IPaiementService _paiementService;
        private readonly IHardwareService _hardwareService;

        public ControlerAccesExamenUseCase(
            IIdentifiantRepository identifiantRepository,
            IAccesExamenRepository accesExamenRepository,
            IPaiementService paiementService,
            IHardwareService hardwareService)
        {
            _identifiantRepository = identifiantRepository;
            _accesExamenRepository = accesExamenRepository;
            _paiementService = paiementService;
            _hardwareService = hardwareService;
        }

        public async Task<bool> ControlerAccesAsync(int salleId)
        {
            var carteCode = await _hardwareService.ScannerCarteRFIDAsync();
            var empreinteCode = await _hardwareService.ScannerEmpreinteDigitaleAsync();

            if (string.IsNullOrEmpty(carteCode) || string.IsNullOrEmpty(empreinteCode))
                return false;

            var response = await VerifierEtExecuterAccesAsync(carteCode, empreinteCode, salleId);
            return response.AccesAutorise;
        }

        public async Task<AccesResponseDTO> VerifierAccesAsync(AccesRequestDTO request)
        {
            return await VerifierEtExecuterAccesAsync(request.CarteCode, request.EmpreinteCode, request.SalleId);
        }

        private async Task<AccesResponseDTO> VerifierEtExecuterAccesAsync(string carteCode, string empreinteCode, int salleId)
        {
            var identifiant = await _identifiantRepository.GetByCodesAsync(carteCode, empreinteCode);
            if (identifiant == null)
            {
                await _hardwareService.AfficherMessageOLEDAsync(ResultatAccesEnum.IdentifiantsInvalides);
                await _hardwareService.AllumerLEDAsync(false);
                return new AccesResponseDTO
                {
                    AccesAutorise = false,
                    Message = "Identifiants invalides",
                    DateAcces = null
                };
            }

            var etudiantId = identifiant.EtudiantId;
            var horaireId = (int)DateTime.Now.TimeOfDay.TotalHours;
            var accesValide = await _accesExamenRepository.HasAccessAsync(etudiantId, salleId, horaireId);
            if (!accesValide)
            {
                await _hardwareService.AfficherMessageOLEDAsync(ResultatAccesEnum.PasExamenAujourdhui);
                await _hardwareService.AllumerLEDAsync(false);
                return new AccesResponseDTO
                {
                    AccesAutorise = false,
                    Message = "Aucun examen aujourd’hui dans cette salle.",
                    DateAcces = null
                };
            }

            var paiementOK = await _paiementService.VerifierPaiementAsync(identifiant.EtudiantMatricule);
            if (!paiementOK)
            {
                await _hardwareService.AfficherMessageOLEDAsync(ResultatAccesEnum.PaiementNonValide);
                await _hardwareService.AllumerLEDAsync(false);
                return new AccesResponseDTO
                {
                    AccesAutorise = false,
                    Message = "Paiement non valide",
                    DateAcces = null
                };
            }

            // Tout est OK
            await _hardwareService.AfficherMessageOLEDAsync(ResultatAccesEnum.AccesAutorise);
            await _hardwareService.AllumerLEDAsync(true);
            await _hardwareService.OuvrirPorteAsync();

            return new AccesResponseDTO
            {
                AccesAutorise = true,
                Message = "Accès autorisé",
                DateAcces = DateTime.Now
            };
        }
    }
}
