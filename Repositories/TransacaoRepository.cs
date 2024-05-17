using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Models;
using portifolioInvestimento.Services;

namespace portifolioInvestimento.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly IInvestimentoService _investimentoService;
    private readonly IUsuarioService _usuarioService;
    private readonly PortifolioDbContext _context;

    public TransacaoRepository(IInvestimentoService investimentoService, PortifolioDbContext context, IUsuarioService usuarioService)
    {
        _investimentoService = investimentoService;
        _context = context;
        _usuarioService = usuarioService;
    }

    public async Task<Transacao> Comprar(Transacao transacao)
    {
        transacao.TipoTransacao = TipoTransacao.Compra;
        _context.transacao.Add(transacao);
        await _context.SaveChangesAsync();
        return transacao;


    }

    public async Task<IEnumerable<Transacao>> ListarTransacoes()
    {
        return await _context.transacao.OrderBy(x => x.NomeInvestimento).ToListAsync();
    }

    public async Task<Transacao> ListarTransacoesNome(string nome)
    {
        return await _context.transacao.Where(x => x.NomeInvestimento == nome).FirstOrDefaultAsync();
    }

    public async Task<Transacao> Vender(Transacao transacao)
    {
        transacao.TipoTransacao = TipoTransacao.Venda;
        _context.transacao.Add(transacao);
        await _context.SaveChangesAsync();
        return transacao;

    }
}
