using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> DeleteAsync(int id)
        {
            var curso = await _context.Curso.Where(c => c.Id == id && !c.Excluido).FirstOrDefaultAsync();
            if (curso == null) return null;

            curso.Excluido = true;
            _context.Curso.Update(curso);   
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            return await _context.Curso.Where(c => !c.Excluido).ToListAsync();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Curso.Where(c => c.Id == id && !c.Excluido).FirstOrDefaultAsync();
        }
        
        public async Task<Curso> UpdateAsync(Curso curso)
        {
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
