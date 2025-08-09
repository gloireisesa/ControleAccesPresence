using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class JournalPresenceDTO
    {
        public string EtudiantNom { get; set; }
        public DateTime? HeureEntree { get; set; }
        public DateTime? HeureSortie { get; set; }
        public string Statut { get; set; }

        public string EtudiantMatricule { get; set; }
        public string SalleNom { get; set; }
        public int EtudiantId { get; internal set; }
        public string Matricule { get; internal set; }
        public string NomComplet { get; internal set; }
        public int SalleId { get; internal set; }
        public int SessionId { get; internal set; }

        public string SessionNom { get; internal set; }
        public DateTime Date { get; internal set; }
    }
}
