using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Identifiant
    {
        public int Id { get; set; }
        public int EtudiantId { get; set; }

        public string EtudiantMatricule { get; set; }
        public string Type { get; set; } // Ex: "CARTE", "EMPREINTE"
        public string Valeur { get; set; } // Code RFID ou Hash Empreinte

        public Etudiant Etudiant { get; set; }
        public string CarteRFID { get; set; }
        public string EmpreinteDigitale { get; set; }
        public string EmpreinteCode { get; set; }
        public string CarteCode { get; set; }
    }
}
