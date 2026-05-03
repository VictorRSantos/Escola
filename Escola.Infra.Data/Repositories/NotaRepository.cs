using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _context;

        public NotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Nota> AddAsync(Nota nota)
        {
            _context.Nota.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<Nota> DeleteAsync(int id)
        {
            var nota = await _context.Nota.Where(n => !n.Excluido && n.Id == id).FirstOrDefaultAsync();
            if (nota == null) return null;

            nota.Excluido = true;
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<List<Nota>> GetAllAsync()
        {
            return await _context.Nota.Where(n => !n.Excluido). ToListAsync();
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Nota.Where(n => !n.Excluido && n.Id == id).FirstOrDefaultAsync();
        }   
        
        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}
