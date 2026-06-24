using Escola.API.Extensions;
using Escola.API.Models;
using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CriarTurma(TurmaPostDTO turmaPostDTO)
        {

            var createdTurma = await _turmaService.AddAsync(turmaPostDTO);

            return Ok("Turma criada com sucesso!");
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> AtualizarTurma(TurmaPutDTO turmaPutDTO)
        {
            var updatedTurma = await _turmaService.UpdateAsync(turmaPutDTO);
            if (updatedTurma == null)
            {
                return BadRequest("Turma não encontrada. Verifique o ID e tente novamente.");
            }
            return Ok("Turma atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeleteTurma(int id)
        {
            var deletedTurma = await _turmaService.DeleteAsync(id);
           
            return Ok("Turma excluída com sucesso!");
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetTurmaById(int id)
        {
            var turma = await _turmaService.GetByIdAsync(id);
           
            return Ok(turma);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> ListarTurmas([FromQuery] int pageNumber, int pageSize)
        {
            var turmas = await _turmaService.GetAllAsync(pageNumber, pageSize);
            Response.AddPaginationHeader(new PaginationHeader(turmas.CurrentPage, turmas.PageSize, turmas.TotalCount, turmas.TotalPages));
            return Ok(turmas);
        }

        [HttpGet("user")]
        [Authorize(Roles = "Aluno")]
        public async Task<ActionResult> ObterTodasTurmasPorUsuario(int idUsuario, [FromQuery] int pageNumber, int pageSize)
        {
            var userId = User.GetUserId();
            var turmas = await _turmaService.GetTurmaByUsuario(userId, pageNumber, pageSize);
            return Ok(turmas);
        }

    }
}
