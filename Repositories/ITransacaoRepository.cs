using portifolioInvestimento.Models;

namespace portifolioInvestimento.Repositories;

public interface ITransacaoRepository
{
    public Task<Transacao> Comprar(Transacao transacao);

    //public Task<Transacao> Vender(Transacao transacao);
}
