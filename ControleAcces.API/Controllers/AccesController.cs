using ControleAcces.Application.UseCases;
using ControleAcces.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcces.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccesController : ControllerBase
    {
        private readonly ControlerAccesExamenUseCase _useCase;

        public AccesController(ControlerAccesExamenUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("VerifierAcces")]
        public async Task<IActionResult> VerifierAcces([FromBody] AccesRequestDTO request)        {
            var result = await _useCase.VerifierAccesAsync(request);
            if (!result.AccesAutorise)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
