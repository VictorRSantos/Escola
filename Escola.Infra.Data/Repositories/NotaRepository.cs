using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Helpers;
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

        public async Task<PagedList<Nota>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Nota.Where(n => !n.Excluido).AsNoTracking();
            return await PaginationHelper.CreatePagedListAsync(query, pageNumber, pageSize);
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Nota.Where(n => !n.Excluido && n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Nota>> GetNotasByTurmaUsuario(int idTurma, int idUsuario)
        {
            return await _context.Nota.Where(n => !n.Excluido && n.Matricula.TurmaId == idTurma && n.Matricula.UsuarioId == idUsuario).ToListAsync();
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}
