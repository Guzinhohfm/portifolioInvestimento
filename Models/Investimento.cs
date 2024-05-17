using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.Models;

public class Investimento : BaseEntity
{
    public string Nome { get; set; }
    public TipoRisco? TipoRisco { get; set; }
    public DateTime ValidadeProduto { get; set; }

    public Boolean Ativo { get; set; }
  
}
