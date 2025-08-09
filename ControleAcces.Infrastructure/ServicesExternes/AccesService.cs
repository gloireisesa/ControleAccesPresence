using ControleAcces.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Infrastructure.ServicesExternes
{
    public class AccesService : IAccesService
    {
        private readonly HttpClient _httpClient;

        public AccesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccesResponseDTO?> VerifierAccesAsync(AccesRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/acces/verifier", request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<AccesResponseDTO>();
            }
            return null;
        }
    }

    public interface IAccesService
    {
        Task<AccesResponseDTO?> VerifierAccesAsync(AccesRequestDTO request);
    }
}
