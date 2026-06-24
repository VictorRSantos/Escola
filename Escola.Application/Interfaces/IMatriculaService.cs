using Escola.Application.DTOs.Matricula;
using Escola.Domain.Pagination;

namespace Escola.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<MatriculaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO);
        Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO);
        Task<MatriculaGetDTO> DeleteAsync(int id);
    }
}
