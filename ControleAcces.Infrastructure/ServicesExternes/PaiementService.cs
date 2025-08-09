using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Infrastructure.ServicesExternes
{
    public class PaiementService : IPaiementService
    {
        private readonly HttpClient _httpClient;

        public PaiementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> VerifierPaiementAsync(string matricule)
        {
            // Exemple d’appel API externe de paiement
            var response = await _httpClient.GetAsync($"https://monapi-paiement.com/api/paiements/verify/{matricule}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<bool>();
                return result;
            }
            return false;
        }
    }
}
