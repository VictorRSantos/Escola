using Escola.Application.DTOs.Matricula;

namespace Escola.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task<MatriculaGetDatailDTO> GetByIdAsync(int id);
        Task<List<MatriculaGetDatailDTO>> GetAllAsync();
        Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO);
        Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO);
        Task<MatriculaGetDTO> DeleteAsync(int id);
    }
}
