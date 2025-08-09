using ControleAcces.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcces.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RapportController : ControllerBase
    {
        private readonly GenererRapportPresenceUseCase _useCase;

        public RapportController(GenererRapportPresenceUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("Generer")]
        public async Task<IActionResult> GenererRapport(string? sessionId, string? salleId, string? matricule, DateTime? date)
        {
            var rapport = await _useCase.GenererRapportAsync(sessionId, salleId, matricule, date);
            return Ok(rapport);
        }
    }
}
