using portifolioInvestimento.DTOS;

namespace portifolioInvestimento.Services;

public interface ITransacaoService
{
    Task Comprar(TransacaoDTO transacaoDTO);

    Task Vender(TransacaoDTO transacaoDTO);

    Task<TransacaoDTO> ListarTransacaoNome(string nome);

    Task<IEnumerable<TransacaoDTO>> ListarTransacoes();

}
