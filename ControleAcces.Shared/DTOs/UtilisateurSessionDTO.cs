using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Shared.DTOs
{
    public class UtilisateurSessionDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public string Role { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public static class SessionUtilisateur
    {
        public static UtilisateurSessionDTO? Current { get; set; }
    }
}
