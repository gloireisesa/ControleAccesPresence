using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string AnneeAcademique { get; set; }
        public ICollection<HoraireExamen> HoraireExamens { get; set; } = new List<HoraireExamen>();
    }
}
