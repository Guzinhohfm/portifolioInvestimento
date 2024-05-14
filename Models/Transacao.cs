namespace portifolioInvestimento.Models;

public class Transacao
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int InvestimentoId { get; set; }

    public decimal ValorTransacao { get; set; }

    public DateTime DataTransacao { get; set; }

    public TipoTransacao TipoTransacao { get; set;}

}
