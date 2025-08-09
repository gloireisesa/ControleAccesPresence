using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Paiement
    {
        public int Id { get; set; }
        public string Matricule { get; set; } // Ou le type de données approprié pour la colonne Matricule
        public bool EstPaye { get; set; }
        public decimal Montant { get; set; }
        public DateTime DatePaiement { get; set; } 

        public Etudiant Etudiant { get; set; }
        public int EtudiantId { get; set; }
    }
}
