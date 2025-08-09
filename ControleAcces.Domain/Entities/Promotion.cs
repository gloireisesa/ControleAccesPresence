using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public ICollection <Etudiant> Etudiants { get; set; } = new List<Etudiant>();
        //public ICollection<HoraireExamen> HorairesExamens { get; set; } = new List<HoraireExamen>();
        //public HoraireExamen HoraireExamens { get; set; }
        //public ICollection<Etudiant> Etudiants { get; set; } = new List<Etudiant>();

        // ✅ Doit être une collection pour 1-n
        public ICollection<HoraireExamen> HoraireExamens { get; set; } = new List<HoraireExamen>();
    }
}
