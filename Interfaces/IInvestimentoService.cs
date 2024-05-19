using portifolioInvestimento.DTOS;
using portifolioInvestimento.Models;


namespace portifolioInvestimento.Interfaces;

public interface IInvestimentoService
{
    Task<IEnumerable<InvestimentoDTO>> ListarInvestimentos(int skip, int take);

    Task<InvestimentoDTO> ListarInvestimentoNome(string nome);

    Task<InvestimentoDTO> ListarInvestimentoId(int id);

    Task<InvestimentoDTO> AdicionarInvestimento(InvestimentoDTO investimentoDTO);

    Task EditarInvestimento(InvestimentoDTO investimentoDTO);
    Task DesativarInvestimento(int id);

}
