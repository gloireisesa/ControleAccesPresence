using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using ControleAcces.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Infrastructure.Repositories
{
    public class HoraireExamenRepository : IHoraireExamenRepository
    {
        private readonly ApplicationDbContext _context;

        public HoraireExamenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HoraireExamen horaire)
        {
            await _context.HoraireExamens.AddAsync(horaire);
            await _context.SaveChangesAsync();
        }

        public async Task<HoraireExamen> GetByIdAsync(int id)
        {
            return await _context.HoraireExamens.FindAsync(id);
        }

        public async Task<IEnumerable<HoraireExamen>> GetAllAsync()
        {
            return await _context.HoraireExamens.ToListAsync();
        }

        public Task UpdateAsync(HoraireExamen horaireExamen)
        {
            throw new NotImplementedException();
        }
    }
}
