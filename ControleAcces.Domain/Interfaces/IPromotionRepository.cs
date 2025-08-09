using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Domain.Interfaces
{
    public interface IPromotionRepository
    {
        Task<Promotion> GetByIdAsync(int id);
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task AddAsync(Promotion promotion);
        Task UpdateAsync(Promotion promotion);
    }
}
