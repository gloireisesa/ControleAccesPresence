using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class RapportPresenceDTO
    {
        public string Matricule { get; set; }
        public string NomComplet { get; set; }
        public string Salle { get; set; }
        public DateTime? HeureEntree { get; set; }
        public DateTime? HeureSortie { get; set; }
    }

}
