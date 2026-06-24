using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Domain.Pagination;
using System.Security.Cryptography;

namespace Escola.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var existeUsuario = await _usuarioRepository.ExistUserAsync();

            var usuario = new Usuario
            {
                Nome = usuarioPostDTO.Nome,
                Email = usuarioPostDTO.Email,
                Excluido = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = existeUsuario ? "Aluno" : "Administrador" // O primeiro usuário criado será Admin, os demais serão User
            };

            var createdUsuario = await _usuarioRepository.AddAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = createdUsuario.Id,
                Nome = createdUsuario.Nome,
                Email = createdUsuario.Email,
                Perfil = createdUsuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> DeleteAsync(int id)
        {
            var usuarioDeleted = await _usuarioRepository.DeleteAsync(id);

            if (usuarioDeleted == null)
                throw new InvalidOperationException("Usuário não encontrado");

            return new UsuarioGetDTO
            {
                Id = usuarioDeleted.Id,
                Nome = usuarioDeleted.Nome,
                Email = usuarioDeleted.Email,
                Perfil = usuarioDeleted.Perfil
            };
        }

        public async Task<bool> ExistUserAsync()
        {
           return await _usuarioRepository.ExistUserAsync();
        }

        public async Task<PagedList<UsuarioGetDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var usuarios = await _usuarioRepository.GetAllAsync(pageNumber, pageSize);
            var usuarioDtos = usuarios.Select(u => new UsuarioGetDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Perfil = u.Perfil
            }).ToList();

            return new PagedList<UsuarioGetDTO>(usuarioDtos, usuarios.CurrentPage, usuarios.PageSize, usuarios.TotalCount);
        }

        public async Task<UsuarioGetDTO> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado");

            return new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado");

            usuario.Nome = usuarioPutDTO.Nome;
            usuario.Email = usuarioPutDTO.Email;

            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = updatedUsuario.Id,
                Nome = updatedUsuario.Nome,
                Email = updatedUsuario.Email,
                Perfil = updatedUsuario.Perfil
            };  
        }
    }
}
