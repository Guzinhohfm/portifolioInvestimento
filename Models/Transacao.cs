namespace portifolioInvestimento.Models;

public class Transacao : BaseEntity
{ 

    public int ClientId { get; set; }

    public int InvestimentoId { get; set; }

    public string NomeInvestimento {  get; set; }

    public decimal ValorTransacao { get; set; }

    public DateTime DataTransacao { get; set; }

    public TipoTransacao TipoTransacao { get; set;}

}
