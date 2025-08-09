using ControleAcces.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcces.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtudiantController : ControllerBase
    {
        private readonly EnrolerEtudiantUseCase _useCase;

        public EtudiantController(EnrolerEtudiantUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{matricule}")]
        public async Task<IActionResult> GetEtudiant(string matricule)
        {
            var etudiant = await _useCase.ChercherEtudiantAsync(matricule);
            if (etudiant == null)
                return NotFound();

            return Ok(etudiant);
        }
    }
}
