using Escola.Application.DTOs.Nota;

namespace Escola.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaGetDTO> GetByIdAsync(int id);
        Task<List<NotaGetDTO>> GetAllAsync();
        Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO);
        Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO);
        Task<NotaGetDTO> DeleteAsync(int id);
    }
}
