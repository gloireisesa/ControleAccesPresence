using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Services
{
    public class PromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<Promotion> GetByIdAsync(int id)
        {
            return await _promotionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await _promotionRepository.GetAllAsync();
        }

        public async Task AjouterPromotionAsync(Promotion promotion)
        {
            await _promotionRepository.AddAsync(promotion);
        }

        public async Task ModifierPromotionAsync(Promotion promotion)
        {
            await _promotionRepository.UpdateAsync(promotion);
        }
    }
}