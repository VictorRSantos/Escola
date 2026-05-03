using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Curso
{
    public class CursoPutDTO
    {
        [Required(ErrorMessage = "O identificador do curso é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome do curso não pode exceder 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do curso é obrigatória")]
        [MaxLength(200, ErrorMessage = "A descrição do curso não pode exceder 200 caracteres")]
        public string Descricao { get; set; }
    }
}
