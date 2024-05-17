using portifolioInvestimento.Models;
using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.DTOS;

public class InvestimentoDTO
{
    public int Id { get; set; } 

    [Required(ErrorMessage = "nome do produto é obrigatório")]
    public string nome { get; set; }
    public DateTime validadeProduto { get; set; }

    public TipoRisco? TipoRisco { get; set; }

    public string? Guid { get; set; }

}
