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
    public class JournalPresenceRepository : IJournalPresenceRepository
{
    private readonly ApplicationDbContext _context;

    public JournalPresenceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<JournalPresence>> GetAllAsync()
    {
        return await _context.JournalPresences
            .Include(j => j.Etudiant)
            .Include(j => j.Salle)
            .Include(j => j.Session)
            .ToListAsync();
    }

    public async Task<JournalPresence> GetByIdAsync(int id)
    {
        return await _context.JournalPresences
            .Include(j => j.Etudiant)
            .Include(j => j.Salle)
            .Include(j => j.Session)
            .FirstOrDefaultAsync(j => j.Id == id);
    }

    public async Task AjouterAsync(JournalPresence presence)
    {
        await _context.JournalPresences.AddAsync(presence);
        await _context.SaveChangesAsync();
    }

    public async Task SupprimerAsync(int id)
    {
        var entity = await _context.JournalPresences.FindAsync(id);
        if (entity != null)
        {
            _context.JournalPresences.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<JournalPresence>> GetBySessionIdAsync(int sessionId)
    {
        return await _context.JournalPresences
            .Where(j => j.SessionId == sessionId)
            .Include(j => j.Etudiant)
            .Include(j => j.Salle)
            .ToListAsync();
    }

        public Task AddAsync(JournalPresence journal)
        {
            throw new NotImplementedException();
        }

        public Task MarquerSortieAsync(Guid etudiantId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(object journal)
        {
            throw new NotImplementedException();
        }

       

        public Task MarquerSortieAsync(int etudiantId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(JournalPresence journal)
        {
            throw new NotImplementedException();
        }

        public Task<JournalPresence> GetOuvertByEtudiantIdAsync(int etudiantId)
        {
            throw new NotImplementedException();
        }
    }
}
