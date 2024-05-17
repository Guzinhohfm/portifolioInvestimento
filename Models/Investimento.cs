using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.Models;

public class Investimento
{
    public string nome { get; set; }

    [Key]
    [Required]
    public int id { get; set; }
    public string? Guid { get; set; }
    public TipoRisco? TipoRisco { get; set; }
    public DateTime validadeProduto { get; set; }
  
}
