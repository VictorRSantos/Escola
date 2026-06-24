using Escola.Application.DTOs.Curso;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;

namespace Escola.Application.Services
{
    public class CursoService : ICursoServices
    {
        private readonly ICursoRepository _cursoRepository;
        
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
       
        public async Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO)
        {
            var curso = new Curso
            {
                Nome = cursoPostDTO.Nome,
                Descricao = cursoPostDTO.Descricao
            };

            var createCurso = await _cursoRepository.AddAsync(curso);

            return new CursoGetDTO
            {
                Id = createCurso.Id,
                Nome = createCurso.Nome,
                Descricao = createCurso.Descricao
            };
        }

        public async Task<CursoGetDTO> DeleteAsync(int id)
        {
            var deletedCurso = await _cursoRepository.DeleteAsync(id);
            if (deletedCurso == null)
                throw new NotFoundException("Curso não encontrado");

            return new CursoGetDTO
            {
                Id = deletedCurso.Id,
                Nome = deletedCurso.Nome,
                Descricao = deletedCurso.Descricao
            };
        }

        public async Task<PagedList<CursoGetDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var cursos = await _cursoRepository.GetAllAsync(pageNumber, pageSize);
            var cursosDTO = cursos.Select(c => new CursoGetDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            }).ToList();
            return new PagedList<CursoGetDTO>(cursosDTO, cursos.CurrentPage, cursos.PageSize, cursos.TotalCount);
        }

        public async Task<CursoGetDTO> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
                throw new NotFoundException("Curso não encontrado");

            return new CursoGetDTO
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao
            };
        }

        public async Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO)
        {
            var curso = new Curso
            {
                Id = cursoPutDTO.Id,
                Nome = cursoPutDTO.Nome,
                Descricao = cursoPutDTO.Descricao
            };

            var updatedCurso = await _cursoRepository.UpdateAsync(curso);
            if (updatedCurso == null)
                throw new NotFoundException("Curso não encontrado");

            return new CursoGetDTO
            {
                Id = updatedCurso.Id,
                Nome = updatedCurso.Nome,
                Descricao = updatedCurso.Descricao
            };
        }
    }
}
