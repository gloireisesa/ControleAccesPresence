using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class ModuleDTO
    {
        

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? SalleAffectee { get; set; } = string.Empty;

        public string Session { get; set; }

        public int SalleId { get; set; }
       public string SalleNom{ get; set;} = string.Empty;
    }
}
