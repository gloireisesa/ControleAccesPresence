using ControleAcces.Domain.Interfaces;
using ControleAcces.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Infrastructure.ServicesExternes
{
    public class HardwareService : IHardwareService
    {
        private readonly HttpClient _httpClient;

        public HardwareService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ScannerCarteRFIDAsync()
        {
            var response = await _httpClient.GetAsync("/scanner-carte");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ScannerEmpreinteDigitaleAsync()
        {
            var response = await _httpClient.GetAsync("/scanner-empreinte");
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadAsStringAsync();
        }
        public async Task AfficherMessageOLEDAsync(string message)
        {
            var content = new StringContent($"\"{message}\"", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/afficher-message", content);
        }

        public async Task AfficherMessageOLEDAsync(ResultatAccesEnum resultat)
        {
            string message = resultat switch
            {
                ResultatAccesEnum.AccesAutorise => "Accès autorisé",
                ResultatAccesEnum.PaiementNonValide => "Paiement non valide",
                ResultatAccesEnum.PasExamenAujourdhui => "Pas d'examen aujourd'hui",
                ResultatAccesEnum.Retard => "Accès refusé (retard)",
                ResultatAccesEnum.IdentifiantsInvalides => "Identifiants invalides",
                _ => "Erreur inconnue"

            };

            // Appelle la méthode qui envoie le message en string
            await AfficherMessageOLEDAsync(message);
        }

        public async Task AllumerLEDAsync(bool success)
        {
            var content = new StringContent($"{{\"success\": {success.ToString().ToLower()}}}", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/led", content);
        }

        public async Task OuvrirPorteAsync()
        {
            await _httpClient.PostAsync("/ouvrir-porte", null);
        }
    }

}
