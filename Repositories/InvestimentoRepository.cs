using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Repositories;

public class InvestimentoRepository : IInvestimentoRepository
{

    private readonly PortifolioDbContext _context;

    public InvestimentoRepository(PortifolioDbContext context)
    {
        _context = context;
    }


    public async Task<Investimento> AdicionarInvestimento(Investimento investimento)
    {
        _context.investimentos.Add(investimento);
        await _context.SaveChangesAsync();
        return investimento;

    }

    public async Task<Investimento> EditarInvestimento(Investimento investimentoEditado)
    {
        _context.Entry(investimentoEditado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return investimentoEditado;
    }

    public async Task<Investimento> ListarInvestimentoId(int id)
    {
        return await _context.investimentos.Where(c => c.id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Investimento>> ListarInvestimentos()
    {
        return await _context.investimentos.OrderBy(x => x.valor).ToListAsync();
    }


    public async Task<Investimento> ListarInvestimentosNome(string nome)
    {
        return await _context.investimentos.Where(c => c.nome == nome).FirstOrDefaultAsync();
    }

    public async Task<Investimento> RemoverInvestimento(int id)
    {
        var investimento = await _context.investimentos.Where(c => c.id == id).FirstOrDefaultAsync();
        _context.investimentos.Remove(investimento);
        await _context.SaveChangesAsync();
        return investimento;
    }

}
