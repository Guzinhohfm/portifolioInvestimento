using portifolioInvestimento.DTOS;

namespace portifolioInvestimento.Interfaces;

public interface ITransacaoService
{
    Task<TransacaoDTO> Comprar(TransacaoDTO transacaoDTO);

    Task<TransacaoDTO> Vender(TransacaoDTO transacaoDTO);

    Task<IEnumerable<TransacaoDTO>> GerarExtratoPorInvestimento(int investimentoId, int clientId, int skip, int take);

    Task<IEnumerable<TransacaoDTO>> GerarExtratoTotalCliente(int clientId, int skip, int take);

}
