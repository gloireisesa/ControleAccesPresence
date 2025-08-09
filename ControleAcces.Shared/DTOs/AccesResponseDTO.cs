using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Shared.DTOs
{
    public class AccesResponseDTO
    {
        public bool AccesAutorise { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime? DateAcces { get; set; }
    }
}
