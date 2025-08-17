using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Entities
{
    public class Utilisateur
    {
        public int Id { get; set; } // identifiant auto-incrémenté
        public string Nom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MotDePasse { get; set; } = null!;
        public string Role { get; set; } = null!; // "Admin" ou "Surveillant"
    }
}
