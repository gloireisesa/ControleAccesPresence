using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IIdentifiantRepository
    {
        Task<Identifiant> GetByIdAsync(int id);
        Task<Identifiant> GetByValeurAsync(string valeur);
        Task AddAsync(Identifiant identifiant);
        Task UpdateAsync(Identifiant identifiant);
        Task<Identifiant?> GetByEtudiantIdAsync(int id);
        //Task GetByCodesAsync(string carteCode, string empreinteCode);
        Task HasCodesAsync(string carteCode, string empreinteCode);
        Task<Identifiant?> GetByCodesAsync(string carteCode, string empreinteCode);
    }
}
