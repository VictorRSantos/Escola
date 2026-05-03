using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> GetByIdAsync(int id);
        Task<List<Nota>> GetAllAsync();
        Task<Nota> AddAsync(Nota nota);
        Task<Nota> UpdateAsync(Nota nota);
        Task<Nota> DeleteAsync(int id);
    }
}
