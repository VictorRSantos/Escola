using Escola.Application.DTOs.Curso;

namespace Escola.Application.Interfaces
{
    public interface ICursoServices
    {
        Task<CursoGetDTO> GetByIdAsync(int id);
        Task<List<CursoGetDTO>> GetAllAsync();
        Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO);
        Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO);
        Task<CursoGetDTO> DeleteAsync(int id);
    }
}
