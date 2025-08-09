using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class AccesExamen
    {
        public int Id { get; set; }

        public int EtudiantId { get; set; }
        public int SalleId { get; set; }
        public int ModuleId { get; set; }
        public int HoraireExamenId { get; set; }

        public Etudiant Etudiant { get; set; }
        public Salle Salle { get; set; }
        public Module Module { get; set; }
        public HoraireExamen HoraireExamen { get; set; }
    }
}
