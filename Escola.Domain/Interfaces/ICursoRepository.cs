using Escola.Domain.Entities;
using Escola.Domain.Pagination;
namespace Escola.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso> GetByIdAsync(int id);
        Task<PagedList<Curso>> GetAllAsync(int pageNumber, int pageSize);
        Task<Curso> AddAsync(Curso curso);
        Task<Curso> UpdateAsync(Curso curso);
        Task<Curso> DeleteAsync(int id);
    }
}
