using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IHardwareService
    {
        Task<string> ScannerCarteRFIDAsync();
        Task<string> ScannerEmpreinteDigitaleAsync();
        Task AfficherMessageOLEDAsync(string message);
        Task AllumerLEDAsync(bool success); // true = vert, false = rouge
        Task OuvrirPorteAsync();
        Task AfficherMessageOLEDAsync(ControleAcces.Shared.Enums.ResultatAccesEnum accesAutorise);
    }
}
