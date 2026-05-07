using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Matricula
{
    public class MatriculaPutDTO
    {

        [Required(ErrorMessage = "O ID da matricula é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID da turma é obrigatório.")]
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "A data de expiração é obrigatória.")]
        public DateTime DataExpiracao { get; set; }
    }
}
