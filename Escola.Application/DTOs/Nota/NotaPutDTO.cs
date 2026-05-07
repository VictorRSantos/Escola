using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Nota
{
    public class NotaPutDTO
    {
        [Required(ErrorMessage = "O ID da nota é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID da matrícula é obrigatório.")]
        public int MatriculaId { get; set; }

        [Required(ErrorMessage = "O valor da nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da nota deve estar entre 0 e 100.")]
        public int ValorNota { get; set; }
    }
}
