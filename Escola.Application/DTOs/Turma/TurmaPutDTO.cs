using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaPutDTO
    {
        [Required(ErrorMessage = "O ID da turma é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do curso é obrigatório.")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O nome da turma é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome da turma não pode exceder 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(200, ErrorMessage = "A descrição não pode exceder 200 caracteres.")]
        public string Descricao { get; set; }
    }
}
