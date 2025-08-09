using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Shared.DTOs
{
    public class AccesRequestDTO
    {
        public string UidCarte { get; set; } = string.Empty;
        public string EmpreinteId { get; set; } = string.Empty;

        public int SalleId { get; set; }
        public DateTime DateTentative { get; set; }
        public string CarteCode { get; set; }
        public string EmpreinteCode { get; set; }
    }
}
