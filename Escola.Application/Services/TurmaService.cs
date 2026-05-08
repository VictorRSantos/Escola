using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO)
        {
            var turma = new Turma
            {
                CursoId = turmaPostDTO.CursoId,
                Nome = turmaPostDTO.Nome,
                Descricao = turmaPostDTO.Descricao
            };

            var createdTurma = await _turmaRepository.AddAsync(turma);

            return new TurmaGetDTO
            {
                Id = createdTurma.Id,
                CursoId = createdTurma.CursoId,
                Nome = createdTurma.Nome,
                Descricao = createdTurma.Descricao
            };
        }

        public async Task<TurmaGetDTO> DeleteAsync(int id)
        {
            var turma =  await _turmaRepository.DeleteAsync(id);
            if (turma == null)
                throw new InvalidOperationException("Turma não encontrada");

            return new TurmaGetDTO
            {
                Id = turma.Id,
                CursoId = turma.CursoId,
                Nome = turma.Nome,
                Descricao = turma.Descricao
            };
        }

        public async Task<List<TurmaGetDetailDTO>> GetAllAsync()
        {
            var turmas = await _turmaRepository.GetAllAsync();
            return turmas.Select(t => new TurmaGetDetailDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                Descricao = t.Descricao,
                Curso = new CursoGetDTO
                {
                    Id = t.Curso.Id,
                    Nome = t.Curso.Nome,
                    Descricao = t.Curso.Descricao
                }
            }).ToList();
        }

        public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
        {
            var turma = await _turmaRepository.GetByIdAsync(id);
            if (turma == null)
                throw new InvalidOperationException("Turma não encontrada");

            return new TurmaGetDetailDTO
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                Curso = new CursoGetDTO
                {
                    Id = turma.Curso.Id,
                    Nome = turma.Curso.Nome,
                    Descricao = turma.Curso.Descricao
                }
            };
        }

        public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO)
        {
            var turma = new Turma
            {
                Id = turmaPutDTO.Id,
                CursoId = turmaPutDTO.CursoId,
                Nome = turmaPutDTO.Nome,
                Descricao = turmaPutDTO.Descricao
            };

            var turmaAtualizada = await _turmaRepository.UpdateAsync(turma);
            if (turmaAtualizada == null)
                throw new InvalidOperationException("Turma não encontrada");    
            return new TurmaGetDTO
            {
                Id = turmaAtualizada.Id,
                CursoId = turmaAtualizada.CursoId,
                Nome = turmaAtualizada.Nome,
                Descricao = turmaAtualizada.Descricao
            };
        }
    }
}
