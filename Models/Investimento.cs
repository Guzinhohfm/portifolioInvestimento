using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.Models;

public class Investimento
{
    public string nome { get; set; }

    [Key]
    [Required]
    public int id { get; set; }
    public string? Guid { get; set; }
    public decimal valor { get; set; }
    public DateTime validadeProduto { get; set; }

    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
}
