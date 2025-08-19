using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Etudiant
    {
        
        public int Id { get; set; } // Utilisation de Guid pour l'unicité
        //public int IdEtudiant { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string PostNom { get; set; }
        public string Prenom { get; set; }
        public string Genre { get; set; }
        public string? Email { get; set; }
        public string? CarteRFID { get; set; } // Null au début, rempli lors de l’enrôlement
        public string? EmpreinteHash { get; set; } // Null au début, rempli lors de l’enrôlement

        public int IdPromotion { get; set; }
        public Promotion Promotion { get; set; }

        public int SessionId { get; set; }

        //public ICollection<Identifiant> IdentifiantsAcces { get; set; } = new List<Identifiant>();
        public ICollection<AccesExamen> AccesExamens { get; set; } = new List<AccesExamen>();
        public ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
       //public ICollection<JournalPresence> Presences { get; set; } = new List<JournalPresence>();
        //public JournalPresence JournalPresences { get; set; }
        //public ICollection<HoraireExamen> HoraireExamens { get; set; } = new List<HoraireExamen>();
        public ICollection<JournalPresence> JournalPresences { get; set; } = new List<JournalPresence>();

        public Identifiant? Identifiant { get; set; }
    }
}
