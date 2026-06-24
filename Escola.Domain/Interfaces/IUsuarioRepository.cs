using Escola.Domain.Entities;
using Escola.Domain.Pagination;

namespace Escola.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<PagedList<Usuario>> GetAllAsync(int pageNumber, int pageSize);
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
        Task<Usuario> DeleteAsync(int id);
        Task<bool> ExistUserAsync();
    }
}
