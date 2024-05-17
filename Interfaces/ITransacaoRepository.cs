using portifolioInvestimento.Models;

namespace portifolioInvestimento.Interfaces;

public interface ITransacaoRepository
{
    public Task<Transacao> Comprar(Transacao transacao);

    public Task<Transacao> Vender(Transacao transacao);

    public Task<IEnumerable<Transacao>> ListarTransacoes();
}
