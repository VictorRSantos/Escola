using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
        Task<Usuario> DeleteAsync(int id);
    }
}
