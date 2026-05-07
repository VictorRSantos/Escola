using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services
{
    public class NotaService : INotaService
    {   
        private readonly INotaRepository _notaRepository;

        public NotaService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
        {
            var nota = new Nota
            {
                MatriculaId = notaPostDTO.MatriculaId,
                ValorNota = notaPostDTO.ValorNota,
                Aprovado = notaPostDTO.ValorNota >= 60, // Exemplo de lógica para aprovação
                DataNota = DateTime.UtcNow
            };
            var createdNota = await _notaRepository.AddAsync(nota);

            return new NotaGetDTO
            {
                Id = createdNota.Id,
                MatriculaId = createdNota.MatriculaId,
                ValorNota = createdNota.ValorNota,
                Aprovado = createdNota.Aprovado,
                DataNota = createdNota.DataNota
            };
        }

        public async Task<NotaGetDTO> DeleteAsync(int id)
        {
            var notaDeleted = await _notaRepository.DeleteAsync(id);
            if (notaDeleted == null) throw new InvalidOperationException("Nota não encontrada");
            
            return new NotaGetDTO
            {
                Id = notaDeleted.Id,
                MatriculaId = notaDeleted.MatriculaId,
                ValorNota = notaDeleted.ValorNota,
                Aprovado = notaDeleted.Aprovado,
                DataNota = notaDeleted.DataNota
            };
        }

        public async Task<List<NotaGetDTO>> GetAllAsync()
        {
            var notas = await _notaRepository.GetAllAsync();
            return notas.Select(nota => new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            }).ToList();
        }

        public async Task<NotaGetDTO> GetByIdAsync(int id)
        {
            var nota = await _notaRepository.GetByIdAsync(id);
            if (nota == null) throw new InvalidOperationException("Nota não encontrada");

            return new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            };
        }

        public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
        {
            var nota = new Nota
            {
                Id = notaPutDTO.Id,
                MatriculaId = notaPutDTO.MatriculaId,
                ValorNota = notaPutDTO.ValorNota,
                Aprovado = notaPutDTO.ValorNota >= 60,
                DataNota = DateTime.UtcNow
            };

            var updatedNota = await _notaRepository.UpdateAsync(nota);
            
            if (updatedNota == null) throw new InvalidOperationException("Erro ao atualizar nota");

            return new NotaGetDTO
            {
                Id = updatedNota.Id,
                MatriculaId = updatedNota.MatriculaId,
                ValorNota = updatedNota.ValorNota,
                Aprovado = updatedNota.Aprovado,
                DataNota = updatedNota.DataNota
            };
        }
    }
}
