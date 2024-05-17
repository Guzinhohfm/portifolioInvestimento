using portifolioInvestimento.Models;

namespace portifolioInvestimento.Interfaces;

public interface IInvestimentoRepository
{
    public Task<Investimento> AdicionarInvestimento(Investimento investimento);

    public Task<IEnumerable<Investimento>> ListarInvestimentos();

    public Task<Investimento> ListarInvestimentosNome(string nome);

    public Task<Investimento> ListarInvestimentoId(int id);

    public Task<Investimento> EditarInvestimento(Investimento investimentoEditado);

    public Task<Investimento> DesativarInvestimento(int id);
}
