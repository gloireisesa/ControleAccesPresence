using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.ValueObjects
{
    public class Horaire
    {
        public DateTime Date { get; private set; }
        public string Heure { get; private set; }

        public Horaire(DateTime date, string heure)
        {
            Date = date;
            Heure = heure;
        }
    }
}
