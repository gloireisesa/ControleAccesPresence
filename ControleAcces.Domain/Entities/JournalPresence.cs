using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class JournalPresence
    {
        public int Id { get; set; }
        public int EtudiantId { get; set; }
        public int AccesExamenId { get; set; }

        public DateTime HeureEntree { get; set; }
        public DateTime? HeureSortie { get; set; }

        public DateTime Date { get; set; }

        public string Statut { get; set; } // "Présent", "Sorti", etc.

        public Etudiant Etudiant { get; set; }
        public AccesExamen AccesExamen { get; set; }
        public int SalleId { get; set; }

        public string Session { get; set; }
        public int SessionId { get; set; }
        public Salle Salle { get; set; }
        public HoraireExamen HoraireExamen { get; set; }
        public int HoraireExamenId { get; set; }
        //public Guid EtudiantId { get; set; }
        //public Etudiant Etudiant { get; set; } = new Etudiant();
    }
}
