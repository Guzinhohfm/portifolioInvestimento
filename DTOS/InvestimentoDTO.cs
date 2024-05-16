using portifolioInvestimento.Models;
using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.DTOS;

public class InvestimentoDTO
{
    [Required(ErrorMessage = "nome do produto é obrigatório")]
    public string nome { get; set; }

    [Required(ErrorMessage = "valor do produto é obrigatório")]
    public decimal valor { get; set; }
    public DateTime validadeProduto { get; set; }

}
