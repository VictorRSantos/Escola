using Escola.Domain.Entities;
using Escola.Domain.Pagination;

namespace Escola.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> GetByIdAsync(int id);
        Task<PagedList<Turma>> GetAllAsync(int pageNumber, int pageSize);
        Task<Turma> AddAsync(Turma turma);
        Task<Turma> UpdateAsync(Turma turma);
        Task<Turma> DeleteAsync(int id);
        Task<PagedList<Turma>> GetTurmaByUsuario(int idUsuario, int pageNumber, int pageSize);
    }
}
