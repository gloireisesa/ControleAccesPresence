using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IUtilisateurRepository
    {
        Task<Utilisateur?> GetByEmailAsync(string email);
    }
}
