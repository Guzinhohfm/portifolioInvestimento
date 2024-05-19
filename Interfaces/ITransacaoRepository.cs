using portifolioInvestimento.Models;

namespace portifolioInvestimento.Interfaces;

public interface ITransacaoRepository
{
    public Task<Transacao> Comprar(Transacao transacao);

    public Task<Transacao> Vender(Transacao transacao);

    public Task<IEnumerable<Transacao>> GerarExtratoPorInvestimento(int investimentoId, int clientId, int skip, int take);

    public Task<IEnumerable<Transacao>> GerarExtratoTotalCliente(int clientId, int skip, int take);
}
