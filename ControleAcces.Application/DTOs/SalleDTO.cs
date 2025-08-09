using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.DTOs
{
    public class SalleDTO
    {
        public int Id { get; set; }
        public string? NomSalle { get; set; }
        public int Capacite { get; set; }
        public string? SessionNom { get; set; }
        public int? SessionId { get; set; }

        public string Session { get; set; }

    }
}
