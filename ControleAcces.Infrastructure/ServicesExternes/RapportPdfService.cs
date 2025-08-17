using ControleAcces.Application.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Infrastructure.ServicesExternes
{
    public class RapportPdfService
    {
        public byte[] GenererPdf(List<JournalPresenceDTO> rapport, StatistiquesDTO stats)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);

                    // En-tête
                    page.Header().Text("Rapport de Présence")
                        .FontSize(20).Bold().AlignCenter();

                    page.Content().Column(col =>
                    {
                        if (stats != null)
                        {
                            col.Item().Text($"📊 Total Étudiants: {stats.TotalEtudiants}");
                            col.Item().Text($"✅ Présents: {stats.NombrePresent}");
                            col.Item().Text($"❌ Absents: {stats.NombreAbsent}");
                            col.Item().PaddingVertical(10);
                        }

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                            });

                            // En-tête du tableau
                            table.Header(header =>
                            {
                                header.Cell().Text("Date").Bold();
                                header.Cell().Text("Heure Entrée").Bold();
                                header.Cell().Text("Heure Sortie").Bold();
                                header.Cell().Text("Étudiant").Bold();
                                header.Cell().Text("Salle").Bold();
                                header.Cell().Text("Session").Bold();
                            });

                            // Lignes
                            foreach (var p in rapport)
                            {
                                table.Cell().Text(p.Date.ToShortDateString());
                                table.Cell().Text(p.HeureEntree.HasValue ? p.HeureEntree.Value.ToString("HH:mm") : "-");
                                table.Cell().Text(p.HeureSortie.HasValue ? p.HeureSortie.Value.ToString("HH:mm") : "-");
                                table.Cell().Text(p.NomComplet ?? "-");
                                table.Cell().Text(p.SalleNom ?? "-");
                                table.Cell().Text(p.SessionNom ?? "-");
                            }
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Généré le {DateTime.Now:dd/MM/yyyy HH:mm}");
                });
            });

            return document.GeneratePdf();
        }
    }
}
