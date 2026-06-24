using Escola.API.Extensions;
using Escola.API.Models;
using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CriarNota(NotaPostDTO notaPostDTO)
        {
            var createdNota = await _notaService.AddAsync(notaPostDTO);
            if (createdNota == null)
            {
                return BadRequest("Não foi possível criar a nota. Verifique os dados e tente novamente.");
            }

            return Ok("Nota criada com sucesso!");
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> AtualizarNota(NotaPutDTO notaPutDTO)
        {
            var updatedNota = await _notaService.UpdateAsync(notaPutDTO);
            if (updatedNota == null)
            {
                return NotFound("Nota não encontrada.");
            }
            return Ok("Nota atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeletarNota(int id)
        {
            var deletedNota = await _notaService.DeleteAsync(id);
            if (deletedNota == null)
            {
                return NotFound("Nota não encontrada.");
            }
            return Ok("Nota deletada com sucesso!");
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> ObterNota(int id)
        {
            var nota = await _notaService.GetByIdAsync(id);
            if (nota == null)
            {
                return NotFound("Nota não encontrada.");
            }
            return Ok(nota);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> ObterTodasNotas([FromQuery] int pageNumber, int pageSize)
        {
            var notas = await _notaService.GetAllAsync(pageNumber, pageSize);
            Response.AddPaginationHeader(new PaginationHeader(notas.CurrentPage, notas.PageSize, notas.TotalCount, notas.TotalPages));
            return Ok(notas);
        }

        [HttpGet("user/turma/{id}")]
        [Authorize(Roles = "Administrador, Aluno")]
        public async Task<ActionResult> ObterTodasNotasPorUsuario(int id)
        {
            var userId = User.GetUserId();
            var notas = await _notaService.GetNotasByTurmaUsuario(id, userId);
            return Ok(notas);
        }

    }
}
