using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IPaiementService
    {
        Task<bool> VerifierPaiementAsync(string matricule);
        //Task<bool> VerifierPaiementAsync(Guid etudiantId);
    }
}
