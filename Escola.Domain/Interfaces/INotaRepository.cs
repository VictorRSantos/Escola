using Escola.Domain.Entities;
using Escola.Domain.Pagination;

namespace Escola.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> GetByIdAsync(int id);
        Task<PagedList<Nota>> GetAllAsync(int pageNumber, int pageSize);
        Task<Nota> AddAsync(Nota nota);
        Task<Nota> UpdateAsync(Nota nota);
        Task<Nota> DeleteAsync(int id);
        Task<List<Nota>> GetNotasByTurmaUsuario(int idTurma, int idUsuario);
    }
}
