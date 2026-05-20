using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoServices _cursoServices;

        public CursoController(ICursoServices cursoServices)
        {
            _cursoServices = cursoServices;
        }

        [HttpPost]
        public async Task<ActionResult> CriarCurso(CursoPostDTO cursoPostDTO)
        {
            var createdCurso = await _cursoServices.AddAsync(cursoPostDTO);
            if (createdCurso == null)
            {
                return BadRequest("Não foi possível criar o curso. Verifique os dados e tente novamente.");
            }
            return Ok("Curso criado com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarCurso(CursoPutDTO cursoPutDTO)
        {
            var updatedCurso = await _cursoServices.UpdateAsync(cursoPutDTO);
            if (updatedCurso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok("Curso atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCurso(int id)
        {
            var deletedCurso = await _cursoServices.DeleteAsync(id);
            if (deletedCurso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok("Curso deletado com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObterCursoPorId(int id)
        {
            var curso = await _cursoServices.GetByIdAsync(id);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok(curso);
        }

        [HttpGet]
        public async Task<ActionResult> ListarCursos()
        {
            var cursos = await _cursoServices.GetAllAsync();
            return Ok(cursos);
        }
    }
}
