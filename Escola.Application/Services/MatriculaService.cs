using Escola.Application.DTOs.Matricula;
using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository, ITurmaRepository turmaRepository, IUsuarioRepository usuarioRepository)
        {
            _matriculaRepository = matriculaRepository;
            _turmaRepository = turmaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
        {
            if (await _usuarioRepository.GetByIdAsync(matriculaPostDTO.UsuarioId) == null)
                throw new NotFoundException("Usuário não encontrado");

            if (await _turmaRepository.GetByIdAsync(matriculaPostDTO.TurmaId) == null)
                throw new NotFoundException("Turma não encontrada");

            var matricula = new Matricula
            {
                UsuarioId = matriculaPostDTO.UsuarioId,
                TurmaId = matriculaPostDTO.TurmaId,
                DataMatricula = DateTime.UtcNow,
                DataExpiracao = matriculaPostDTO.DataExpiracao,
                Ativa = true
            };

            var createdMatricula = await _matriculaRepository.AddAsync(matricula);
            return new MatriculaGetDTO
            {
                Id = createdMatricula.Id,
                UsuarioId = createdMatricula.UsuarioId,
                TurmaId = createdMatricula.TurmaId,
                DataMatricula = createdMatricula.DataMatricula,
                DataExpiracao = createdMatricula.DataExpiracao,
                Ativa = createdMatricula.Ativa
            };
        }


        public async Task<MatriculaGetDTO> DeleteAsync(int id)
        {
            var deleteMatricula = await _matriculaRepository.DeleteAsync(id);
            if (deleteMatricula == null)
                throw new NotFoundException("Matrícula não encontrada");

            return new MatriculaGetDTO
            {
                Id = deleteMatricula.Id,
                UsuarioId = deleteMatricula.UsuarioId,
                TurmaId = deleteMatricula.TurmaId,
                DataMatricula = deleteMatricula.DataMatricula,
                DataExpiracao = deleteMatricula.DataExpiracao,
                Ativa = deleteMatricula.Ativa
            };
        }

        public async Task<List<MatriculaGetDatailDTO>> GetAllAsync()
        {
            var matriculas = await _matriculaRepository.GetAllAsync();
            var matriculaGetDetailDTOs = new List<MatriculaGetDatailDTO>();
            matriculaGetDetailDTOs.AddRange(matriculas.Select(m => new MatriculaGetDatailDTO
            {
                Id = m.Id,
                DataMatricula = m.DataMatricula,
                DataExpiracao = m.DataExpiracao,
                Ativa = m.Ativa,
                Usuario = new UsuarioGetDTO
                {
                    Id = m.Usuario.Id,
                    Nome = m.Usuario.Nome,
                    Email = m.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = m.Turma.Id,
                    Nome = m.Turma.Nome,
                    Descricao = m.Turma.Descricao
                }
            }));

            return matriculaGetDetailDTOs;
        }

        public async Task<MatriculaGetDatailDTO> GetByIdAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
                throw new NotFoundException("Matrícula não encontrada");

            return new MatriculaGetDatailDTO
            {
                Id = matricula.Id,
                DataMatricula = matricula.DataMatricula,
                DataExpiracao = matricula.DataExpiracao,
                Ativa = matricula.Ativa,
                Usuario = new UsuarioGetDTO
                {
                    Id = matricula.Usuario.Id,
                    Nome = matricula.Usuario.Nome,
                    Email = matricula.Usuario.Email
                },
                Turma = new TurmaGetDTO
                {
                    Id = matricula.Turma.Id,
                    Nome = matricula.Turma.Nome,
                    Descricao = matricula.Turma.Descricao
                }
            };
        }

        public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO)
        {
            if(await _turmaRepository.GetByIdAsync(matriculaPutDTO.TurmaId) == null)
                throw new NotFoundException("Turma não encontrada");
            
            if (await _matriculaRepository.GetByIdAsync(matriculaPutDTO.Id) == null)
                throw new NotFoundException("Matrícula não encontrada");

            var matricula = new Matricula
            {
                Id = matriculaPutDTO.Id,
                TurmaId = matriculaPutDTO.TurmaId,
                DataExpiracao = matriculaPutDTO.DataExpiracao
            };
            var updatedMatricula = await _matriculaRepository.UpdateAsync(matricula);
            if (updatedMatricula != null)
                throw new NotFoundException("Matrícula não encontrada");

            return new MatriculaGetDTO
            {
                Id = updatedMatricula.Id,
                UsuarioId = updatedMatricula.UsuarioId,
                TurmaId = updatedMatricula.TurmaId,
                DataMatricula = updatedMatricula.DataMatricula,
                DataExpiracao = updatedMatricula.DataExpiracao,
                Ativa = updatedMatricula.Ativa
            };
        }
    }
}
