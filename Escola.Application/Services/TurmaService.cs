using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;

namespace Escola.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public TurmaService(ITurmaRepository turmaRepository, ICursoRepository cursoRepository, IUsuarioRepository usuarioRepository)
        {
            _turmaRepository = turmaRepository;
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO)
        {
            var curso = await _cursoRepository.GetByIdAsync(turmaPostDTO.CursoId);
            if (curso == null)
                throw new NotFoundException("Curso não encontrado");

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
            var turma = await _turmaRepository.DeleteAsync(id);
            if (turma == null)
                throw new NotFoundException("Turma não encontrada");

            return new TurmaGetDTO
            {
                Id = turma.Id,
                CursoId = turma.CursoId,
                Nome = turma.Nome,
                Descricao = turma.Descricao
            };
        }

        public async Task<PagedList<TurmaGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var turmas = await _turmaRepository.GetAllAsync(pageNumber, pageSize);
            var turmaDto = new List<TurmaGetDetailDTO>(turmas.Select(t => new TurmaGetDetailDTO
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
            }).ToList());

            return new PagedList<TurmaGetDetailDTO>(turmaDto, turmas.CurrentPage, turmas.PageSize, turmas.TotalCount);
        }

        public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
        {
            var turma = await _turmaRepository.GetByIdAsync(id);
            if (turma == null)
                throw new NotFoundException("Turma não encontrada");

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

        public async Task<List<TurmaGetDetailDTO>> GetTurmaByUsuario(int idUsuario)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(idUsuario);
            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado");

            var turmas = await _turmaRepository.GetTurmaByUsuario(idUsuario);
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

        public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO)
        {
            var turma = await _turmaRepository.GetByIdAsync(turmaPutDTO.Id);
            if (turma == null)
                throw new NotFoundException("Turma não encontrada");

            var curso = await _cursoRepository.GetByIdAsync(turmaPutDTO.CursoId);
            if (curso == null)
                throw new NotFoundException("Curso não encontrado");

            turma.Id = turmaPutDTO.Id;
            turma.CursoId = turmaPutDTO.CursoId;
            turma.Nome = turmaPutDTO.Nome;
            turma.Descricao = turmaPutDTO.Descricao;

            var turmaAtualizada = await _turmaRepository.UpdateAsync(turma);
            
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
