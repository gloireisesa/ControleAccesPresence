using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.ValueObjects
{
    public class AccesResult
    {
        public bool EstAutorise { get; set; }
        public string Message { get; set; }
    }
}
