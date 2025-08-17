using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class AuthService
    {
        private readonly IUtilisateurRepository _repo;

        public AuthService(IUtilisateurRepository repo)
        {
            _repo = repo;
        }

        public async Task<Utilisateur?> LoginAsync(string email, string motDePasse)
        {
            var user = await _repo.GetByEmailAsync(email);
            if (user != null && user.MotDePasse == motDePasse)
                return user;
            return null;
        }
    }
}