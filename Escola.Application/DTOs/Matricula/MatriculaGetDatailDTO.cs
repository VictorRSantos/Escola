using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;

namespace Escola.Application.DTOs.Matricula
{
    public class MatriculaGetDatailDTO
    {
        public int Id { get; set; }
        public UsuarioGetDTO Usuario { get; set; }
        public TurmaGetDTO Turma { get; set; }       
        public DateTime DataMatricula { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Ativa { get; set; }        
    }
}
