using portifolioInvestimento.DTOS;

namespace portifolioInvestimento.Services;

public interface IInvestimentoService
{
    Task<IEnumerable<InvestimentoDTO>> ListarInvestimentos();

    Task<InvestimentoDTO> ListarInvestimentoNome(string nome);

    Task<InvestimentoDTO> ListarInvestimentoId(int id);

    Task AdicionarInvestimento(InvestimentoDTO investimentoDTO);

    Task EditarInvestimento (InvestimentoDTO investimentoDTO);
    Task RemoverInvestimento(int id);

}
