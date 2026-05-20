using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        public async Task<ActionResult> CriarMatricula(MatriculaPostDTO matriculaPostDTO)
        {
            var createdMatricula = await _matriculaService.AddAsync(matriculaPostDTO);
            if (createdMatricula == null)
            {
                return BadRequest("Não foi possível criar a matrícula. Verifique os dados e tente novamente.");
            }
            return Ok("Matrícula criada com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarMatricula(MatriculaPutDTO matriculaPutDTO)
        {
            var updatedMatricula = await _matriculaService.UpdateAsync(matriculaPutDTO);
            if (updatedMatricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return Ok("Matrícula atualizada com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarMatricula(int id)
        {
            var deletedMatricula = await _matriculaService.DeleteAsync(id);
            if (deletedMatricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return Ok("Matrícula deletada com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterMatriculaPorId(int id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);
            if (matricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return Ok(matricula);
        }

        [HttpGet]
        public async Task<ActionResult> ListarMatriculas()
        {
            var matriculas = await _matriculaService.GetAllAsync();
            return Ok(matriculas);
        }
    }
}
