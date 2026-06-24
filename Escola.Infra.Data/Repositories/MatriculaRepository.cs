using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Matricula> AddAsync(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> DeleteAsync(int id)
        {
            var matricula = await _context.Matricula.Where(m => m.Id == id && !m.Excluido).FirstOrDefaultAsync();
            if (matricula == null) return null;

            matricula.Excluido = true;
            _context.Matricula.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<PagedList<Matricula>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Matricula.Include(m => m.Usuario).Include(m => m.Turma).Where(m => !m.Excluido).AsNoTracking();
            return await PaginationHelper.CreatePagedListAsync(query, pageNumber, pageSize);
        }

        public async Task<Matricula> GetByIdAsync(int id)
        {
            return await _context.Matricula.Include(m => m.Usuario).Include(m => m.Turma).Where(m => m.Id == id && !m.Excluido).FirstOrDefaultAsync();
        }       
        
        public async Task<Matricula> UpdateAsync(Matricula matricula)
        {
            _context.Matricula.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }
    }
}
