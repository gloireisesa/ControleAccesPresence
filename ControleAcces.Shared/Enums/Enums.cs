using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Shared.Enums
{
    
    public enum Genre
    {
        Masculin,
        Feminin
    }

    public enum StatutPresence
    {
        Present,
        Absent,
        NonJustifie
    }
    public enum ResultatAccesEnum
    {
        AccesAutorise,
        PaiementNonValide,
        PasExamenAujourdhui,
        Retard,
        IdentifiantsInvalides
    }
}
