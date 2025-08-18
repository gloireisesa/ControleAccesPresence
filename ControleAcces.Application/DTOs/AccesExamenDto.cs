using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class AccesExamenDto
    {
        public int EtudiantId { get; set; }
        public int SalleId { get; set; }
        public int ModuleId { get; set; }
        public int HoraireExamenId { get; set; }
    }
}
