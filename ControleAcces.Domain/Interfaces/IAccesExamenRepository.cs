using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IAccesExamenRepository
    {
        Task<AccesExamen> GetByIdAsync(int id);
        Task<IEnumerable<AccesExamen>> GetAllByEtudiantAsync(int id);
        Task AddAsync(AccesExamen accesExamen);
        Task<bool> VerifierAccesAsync(int etudiantId);
        Task<bool> HasAccessAsync(int etudiantId, int salleId, int horaireId);
    }
}
