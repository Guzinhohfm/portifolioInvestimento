using portifolioInvestimento.DTOS;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Services;

public interface IInvestimentoService
{
    Task<IEnumerable<InvestimentoDTO>> ListarInvestimentos();

    Task<InvestimentoDTO> ListarInvestimentoNome(string nome);

    Task<InvestimentoDTO> ListarInvestimentoId(int id);

    Task<InvestimentoDTO> AdicionarInvestimento(InvestimentoDTO investimentoDTO);

    Task EditarInvestimento (InvestimentoDTO investimentoDTO);
    Task RemoverInvestimento(int id);

}
