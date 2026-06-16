using Escola.API.Models;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
        {
            var userExists = await _authenticate.UserExists(usuarioPostDTO.Email);
            if (userExists) {
                return BadRequest(new { message = "Email já cadastrado" });
            }

            var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
            
            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);

            return Ok(new {Nome = usuario.Nome, Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokenUsuario(UserLogin userLogin)
        {
            var usuario = await _authenticate.GetUsuarioByEmail(userLogin.Email);
            if (usuario == null)
                return BadRequest(new {message = "Usuário ou senha inválidos" });

            var usuarioValido = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Senha);
            if (!usuarioValido)
                return BadRequest(new { message = "Usuário ou senha inválidos" });           

            var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);

            return Ok(new { Nome = usuario.Nome, Token = token });
        }

        [HttpGet("rota-de-teste")]
        [Authorize(Roles = "Administrador, Aluno")]
        public async Task<ActionResult> Test()
        {            
            return Ok(new {message = "Teste realizado com sucesso!"});
        }
    }
}
