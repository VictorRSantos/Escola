using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Matricula
{
    public class MatriculaPostDTO
    {
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O ID da turma é obrigatório.")]
        public int TurmaId { get; set; }
        
        [Required(ErrorMessage = "A data de expiração é obrigatória.")]
        public DateTime DataExpiracao { get; set; }
    }
}
