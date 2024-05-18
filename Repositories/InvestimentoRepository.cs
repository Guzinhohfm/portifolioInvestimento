using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Interfaces;
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
        investimento.Ativo = true;
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
        var investimento =  await _context.investimentos.Where(c => c.Id == id).FirstOrDefaultAsync();
        return investimento;
    }

    public async Task<IEnumerable<Investimento>> ListarInvestimentos()
    {
        return await _context.investimentos.OrderBy(x => x.Nome).Where(x => x.Ativo == true).ToListAsync();
    }


    public async Task<Investimento> ListarInvestimentosNome(string nome)
    {
        return await _context.investimentos.Where(c => c.Nome == nome).FirstOrDefaultAsync();
    }

    public async Task<Investimento> DesativarInvestimento(int id)
    {
        var investimento = await ListarInvestimentoId(id);
        investimento.Ativo = false;
        _context.Entry(investimento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return investimento;
    }

}
