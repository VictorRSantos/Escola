using Escola.Domain.Entities;
using Escola.Domain.Pagination;

namespace Escola.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula> GetByIdAsync(int id);
        Task<PagedList<Matricula>> GetAllAsync(int pageNumber, int pageSize);
        Task<Matricula> AddAsync(Matricula matricula);
        Task<Matricula> UpdateAsync(Matricula matricula);
        Task<Matricula> DeleteAsync(int id);
    }
}
