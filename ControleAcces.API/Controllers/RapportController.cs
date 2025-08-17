using ControleAcces.Application.UseCases;
using ControleAcces.Infrastructure.ServicesExternes;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcces.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RapportController : ControllerBase
    {
        private readonly GenererRapportPresenceUseCase _useCase;
        private readonly RapportPdfService _pdfService;

        public RapportController(GenererRapportPresenceUseCase useCase, RapportPdfService pdfService)
        {
            _useCase = useCase;
            _pdfService = pdfService;
        }

        // ✅ Endpoint pour générer le rapport PDF
        [HttpGet("export")]
        public async Task<IActionResult> ExportRapport(
     string? sessionId,
     string? salleId,
     string? matricule,
     string? promotionId,
     DateTime? date)
        {
            // Si aucun paramètre date n'est fourni, on prend aujourd'hui
            var dateRapport = date ?? DateTime.Today;

            // 🔹 Conversion des strings en int? (nullable)
            int? sessionIdInt = int.TryParse(sessionId, out var sId) ? sId : null;
            int? salleIdInt = int.TryParse(salleId, out var saId) ? saId : null;
            int? promotionIdInt = int.TryParse(promotionId, out var pId) ? pId : null;

            // Récupère les données du rapport
            var rapport = await _useCase.GenererRapportAsync(
                sessionIdInt,
                salleIdInt,
                matricule,
                promotionIdInt,
                dateRapport
            );

            // Génère les statistiques uniquement si pas de promotion
            var stats = promotionIdInt == null
                ? await _useCase.GenererStatistiquesAsync(sessionIdInt, salleIdInt, promotionIdInt, dateRapport)
                : null;

            // Génération du PDF via le service externe
            var pdfBytes = _pdfService.GenererPdf(rapport, stats);

            // Retourne le fichier PDF pour téléchargement
            return File(pdfBytes, "application/pdf", "RapportPresence.pdf");
        }
    }
}