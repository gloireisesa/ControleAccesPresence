using ControleAcces.Application.DTOs;
using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.UseCases
{
    public class EnrolerEtudiantUseCase
    {
        private readonly IEtudiantRepository _etudiantRepository;
        private readonly IIdentifiantRepository _identifiantRepository;
        private readonly IHardwareService _hardwareService;

        public EnrolerEtudiantUseCase(
            IEtudiantRepository etudiantRepository,
            IIdentifiantRepository identifiantRepository,
            IHardwareService hardwareService)
        {
            _etudiantRepository = etudiantRepository;
            _identifiantRepository = identifiantRepository;
            _hardwareService = hardwareService;
        }

        public async Task<EtudiantDTO?> ChercherEtudiantAsync(string matricule)
        {
            var etudiant = await _etudiantRepository.GetByMatriculeAsync(matricule.Trim());
            if (etudiant == null) return null;

            return new EtudiantDTO
            {
                Id = etudiant.Id,
                Matricule = etudiant.Matricule,
                NomComplet = $"{etudiant.Nom} {etudiant.PostNom} {etudiant.Prenom}",
                Email = etudiant.Email,
                Promotion = etudiant.Promotion?.Nom
            };
        }

        public async Task<bool> ScannerCarteRFIDAsync(int etudiantId)
        {
            var carteCode = await _hardwareService.ScannerCarteRFIDAsync();
            if (string.IsNullOrEmpty(carteCode)) return false;

            var identifiant = await _identifiantRepository.GetByEtudiantIdAsync(etudiantId) ?? new Identifiant { EtudiantId = etudiantId };
            identifiant.CarteRFID = carteCode;

            if (identifiant.Id == 0)
                await _identifiantRepository.AddAsync(identifiant);
            else
                await _identifiantRepository.UpdateAsync(identifiant);

            return true;
        }

        public async Task<bool> ScannerEmpreinteDigitaleAsync(int etudiantId)
        {
            var empreinteCode = await _hardwareService.ScannerEmpreinteDigitaleAsync();
            if (string.IsNullOrEmpty(empreinteCode)) return false;

            var identifiant = await _identifiantRepository.GetByEtudiantIdAsync(etudiantId) ?? new Identifiant { Id = etudiantId };
            identifiant.EmpreinteDigitale = empreinteCode;

            if (identifiant.Id == 0)
                await _identifiantRepository.AddAsync(identifiant);
            else
                await _identifiantRepository.UpdateAsync(identifiant);

            return true;
        }
    }

}
