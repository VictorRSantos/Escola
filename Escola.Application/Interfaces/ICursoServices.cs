using Escola.Application.DTOs.Curso;
using Escola.Domain.Pagination;

namespace Escola.Application.Interfaces
{
    public interface ICursoServices
    {
        Task<CursoGetDTO> GetByIdAsync(int id);
        Task<PagedList<CursoGetDTO>> GetAllAsync(int page, int pageSize);
        Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO);
        Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO);
        Task<CursoGetDTO> DeleteAsync(int id);
    }
}
