using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string Session { get; set; }
        public string SalleAffectee { get; set; } = string.Empty;
        public int? SalleId { get; set; }
        public string SalleNom { get; set; } = string.Empty;
        //public string Code { get; set; }

        public ICollection<AccesExamen> AccesExamens { get; set; } = new List<AccesExamen>();
        public ICollection<HoraireExamen> HoraireExamens { get; set; } = new List<HoraireExamen>();
        
    }
}
