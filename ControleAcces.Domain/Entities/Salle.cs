using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Salle
    {
       
        public int Id { get; set; }
        public string NomSalle { get; set; }
        public int Capacite { get; set; }

        public ICollection<AccesExamen> AccesExamens { get; set; } = new List<AccesExamen>();
        public ICollection<JournalPresence> Presences { get; set; } = new List<JournalPresence>();
        public ICollection<HoraireExamen> HoraireExamens { get; set; } = new List<HoraireExamen>();
        public int? SessionId { get; set; }
        public string? SessionNom { get; set; }
        
    }
}
