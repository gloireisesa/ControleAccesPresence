using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class HoraireExamen
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public string Matiere { get; set; } // Ex: "Mathématiques", "Physique", etc.
        
        public ICollection<AccesExamen> AccesExamens { get; set; } = new List<AccesExamen>();
        public ICollection<JournalPresence> JournalPresences { get; set; } = new List<JournalPresence>();
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
        public Salle Salle { get; set; }
        public int SalleId { get; set; }
        public Session Session { get; set; }

        public int? SessionId { get; set; }
        public Module? Module { get; set; }
        public int? ModuleId { get; set; }
        public int IdPromotion { get; set; }
        public Promotion Promotion { get; set; }

        //public ICollection<Module> Modules { get; set; } = new List<Module>();
        //public JournalPresence JournalPresences { get; set; }
    }
}
