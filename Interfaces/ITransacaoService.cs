using portifolioInvestimento.DTOS;

namespace portifolioInvestimento.Interfaces;

public interface ITransacaoService
{
    Task Comprar(TransacaoDTO transacaoDTO);

    Task Vender(TransacaoDTO transacaoDTO);

    Task<IEnumerable<TransacaoDTO>> GerarExtratoPorInvestimento(int investimentoId, int clientId);

    Task<IEnumerable<TransacaoDTO>> GerarExtratoTotalCliente(int clientId);

}
