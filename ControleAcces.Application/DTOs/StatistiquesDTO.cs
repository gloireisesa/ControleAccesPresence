using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class StatistiquesDTO
    {
        public int TotalEtudiants { get; set; }       // Capacité totale ou nombre d’étudiants de la session
        public int NombrePresent { get; set; }        // Nombre d’étudiants présents
        public int NombreAbsent => TotalEtudiants - NombrePresent;  // Calcul automatique

        public decimal TauxPresence { get; internal set; }
    }
}
