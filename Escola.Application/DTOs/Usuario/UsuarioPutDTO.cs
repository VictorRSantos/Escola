using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Usuario
{
    public class UsuarioPutDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(250, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O campo {0} deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Senha { get; set; }
    }
}
