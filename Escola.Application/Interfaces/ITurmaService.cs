using Escola.Application.DTOs.Turma;
using Escola.Domain.Pagination;

namespace Escola.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<TurmaGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<TurmaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO);
        Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO);
        Task<TurmaGetDTO> DeleteAsync(int id);
        Task<List<TurmaGetDetailDTO>> GetTurmaByUsuario(int idUsuario);
    }
}
