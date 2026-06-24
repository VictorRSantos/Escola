using Escola.Application.DTOs.Nota;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;

namespace Escola.Application.Services
{
    public class NotaService : INotaService
    {   
        private readonly INotaRepository _notaRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public NotaService(INotaRepository notaRepository, IMatriculaRepository matriculaRepository)
        {
            _notaRepository = notaRepository;
            _matriculaRepository = matriculaRepository;
        }

        public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
        {
            if (await _matriculaRepository.GetByIdAsync(notaPostDTO.MatriculaId) == null)
                throw new NotFoundException("Matrícula não encontrada");

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
            if (notaDeleted == null)
                throw new NotFoundException("Nota não encontrada");
            
            return new NotaGetDTO
            {
                Id = notaDeleted.Id,
                MatriculaId = notaDeleted.MatriculaId,
                ValorNota = notaDeleted.ValorNota,
                Aprovado = notaDeleted.Aprovado,
                DataNota = notaDeleted.DataNota
            };
        }

        public async Task<PagedList<NotaGetDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var notas = await _notaRepository.GetAllAsync(pageNumber, pageSize);
            return new PagedList<NotaGetDTO>(notas.Select(nota => new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            }).ToList(), notas.CurrentPage, notas.PageSize, notas.TotalCount);
        }

        public async Task<NotaGetDTO> GetByIdAsync(int id)
        {
            var nota = await _notaRepository.GetByIdAsync(id);
            if (nota == null)
                throw new NotFoundException("Nota não encontrada");

            return new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            };
        }

        public async Task<List<NotaGetDTO>> GetNotasByTurmaUsuario(int idTurma, int idUsuario)
        {
            var notas = await _notaRepository.GetNotasByTurmaUsuario(idTurma, idUsuario);
            return notas.Select(nota => new NotaGetDTO
            {
                Id = nota.Id,
                MatriculaId = nota.MatriculaId,
                ValorNota = nota.ValorNota,
                Aprovado = nota.Aprovado,
                DataNota = nota.DataNota
            }).ToList();
        }

        public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
        {
            var existeNota = await _notaRepository.GetByIdAsync(notaPutDTO.Id);
            if (existeNota == null)
                throw new NotFoundException("Nota não encontrada");

            if (notaPutDTO.MatriculaId != existeNota.MatriculaId)
            {
                if (await _matriculaRepository.GetByIdAsync(notaPutDTO.MatriculaId) == null)
                    throw new NotFoundException("Matrícula não encontrada");

                existeNota.MatriculaId = notaPutDTO.MatriculaId;
            }

            existeNota.ValorNota = notaPutDTO.ValorNota;
            existeNota.Aprovado = notaPutDTO.ValorNota >= 60; // Atualiza o status de aprovação com base na nova nota

            var updatedNota = await _notaRepository.UpdateAsync(existeNota);
          
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
