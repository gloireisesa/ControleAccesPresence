using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class EtudiantDTO
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string NomComplet { get; set; }
        public string Email { get; set; }
        public string Promotion { get; set; }
        public string CarteRFID { get; set; }
        public string Empreinte { get; set; }
        public int SessionId { get; set; }
    }
}
