using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int pageNumbers {  get; set; }

        [Range(1, 50, ErrorMessage = "O máximo de itens por página é de 50")]
        public int pageSize { get; set; }
    }
}
