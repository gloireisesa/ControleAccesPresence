using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IEtudiantRepository
    {
        Task<Etudiant> GetByIdAsync(int id);
        Task<Etudiant> GetByMatriculeAsync(string matricule);
        Task<Etudiant> GetByCodeIdentificationAsync(string code);
        Task<IEnumerable<Etudiant>> GetAllAsync();
        Task AddAsync(Etudiant etudiant);
        Task UpdateAsync(Etudiant etudiant);
        //Task GetByIdAsync(object etudiantId);
    }
}
