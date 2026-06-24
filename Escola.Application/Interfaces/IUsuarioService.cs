using Escola.Application.DTOs.Usuario;
using Escola.Domain.Pagination;

namespace Escola.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGetDTO> GetByIdAsync(int id);
        Task<PagedList<UsuarioGetDTO>> GetAllAsync(int pageNumber, int pageSize );
        Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO);
        Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO);
        Task<UsuarioGetDTO> DeleteAsync(int id);
        Task<bool> ExistUserAsync();
    }
}
