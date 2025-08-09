using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class PaiementVerifier
    {
        private readonly IPaiementService _paiementService;

        public PaiementVerifier(IPaiementService paiementService)
        {
            _paiementService = paiementService;
        }

        public async Task<bool> VerifierPaiementEtudiant(string matricule)
        {
            return await _paiementService.VerifierPaiementAsync(matricule);
        }
    }
}
