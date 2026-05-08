using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
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
        public async Task<ActionResult> CriarTurma(TurmaPostDTO turmaPostDTO)
        {

            var createdTurma = await _turmaService.AddAsync(turmaPostDTO);

            if (createdTurma == null)
            {
                return BadRequest("Não foi possível criar a turma. Verifique os dados e tente novamente.");
            }

            return Ok("Turma criada com sucesso!");
        }

        [HttpPut]
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
        public async Task<ActionResult> DeleteTurma(int id)
        {
            var deletedTurma = await _turmaService.DeleteAsync(id);
            if (deletedTurma == null)
            {
                return BadRequest("Turma não encontrada. Verifique o ID e tente novamente.");
            }
            return Ok("Turma excluída com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTurmaById(int id)
        {
            var turma = await _turmaService.GetByIdAsync(id);
            if (turma == null)
            {
                return NotFound("Turma não encontrada.");
            }
            return Ok(turma);
        }

        [HttpGet]
        public async Task<ActionResult> ListarTurmas()
        {
            var turmas = await _turmaService.GetAllAsync();
            return Ok(turmas);
        }

    }
}
