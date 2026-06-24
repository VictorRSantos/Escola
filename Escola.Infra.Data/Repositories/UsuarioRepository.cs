using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.Where(u => u.Id == id && !u.Excluido).FirstOrDefaultAsync();
            if (usuario == null) return null;

            usuario.Excluido = true;
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ExistUserAsync()
        {
            return await _context.Usuario.AnyAsync(u => !u.Excluido);
        }

        public async Task<PagedList<Usuario>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Usuario.Where(u => !u.Excluido).AsNoTracking();
            return await PaginationHelper.CreatePagedListAsync(query, pageNumber, pageSize);
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuario.Where(u => !u.Excluido && u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }        
    }
}
