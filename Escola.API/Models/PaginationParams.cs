using System.ComponentModel.DataAnnotations;

namespace Escola.API.Models
{
    public class PaginationParams
    {   
        [Range(1, int.MaxValue, ErrorMessage = "A pagina deve ser maior que 1.")]
        public int PageNumber { get; set; }

        [Range(1, 50, ErrorMessage = "O tamanho da pagina deve ser entre 1 e 50.")]
        public int PageSize { get; set; }
    }
}
