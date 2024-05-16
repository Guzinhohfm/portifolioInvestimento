using portifolioInvestimento.DTOS;

namespace portifolioInvestimento.Services;

public interface ITransacaoService
{
    Task Comprar(TransacaoDTO transacaoDTO);

    //Task<TransacaoDTO> Vender(TransacaoDTO transacaoDTO);
}
