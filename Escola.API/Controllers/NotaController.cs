using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
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
        public async Task<ActionResult> ObterTodasNotas()
        {
            var notas = await _notaService.GetAllAsync();
            return Ok(notas);
        }

    }
}
