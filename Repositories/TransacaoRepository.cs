using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Interfaces;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    
    private readonly PortifolioDbContext _context;
    private readonly IInvestimentoService _investimentoService;

    public TransacaoRepository(PortifolioDbContext context, IInvestimentoService investimentoService)
    {
        _context = context;
        _investimentoService = investimentoService;
    }

    public async Task<Transacao> Comprar(Transacao transacao)
    {
        transacao.TipoTransacao = TipoTransacao.Compra;

        int idInvestimento = transacao.InvestimentoId;
        var Investimento = await _investimentoService.ListarInvestimentoId(idInvestimento);
        transacao.NomeInvestimento = Investimento.nome;
        transacao.DataTransacao = DateTime.Now;

        _context.transacao.Add(transacao);
        await _context.SaveChangesAsync();
        return transacao;


    }

    public async Task<IEnumerable<Transacao>> GerarExtratoPorInvestimento(int investimentoId, int clientId, int skip, int take)
    {
        return await _context.transacao.Where(x => x.ClientId == clientId && x.InvestimentoId == investimentoId).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<Transacao>> GerarExtratoTotalCliente(int clientId, int skip, int take)
    {
        return await _context.transacao.Where(x => x.ClientId == clientId).Skip(skip).Take(take).ToListAsync();

    }

    public async Task<Transacao> Vender(Transacao transacao)
    {
        transacao.TipoTransacao = TipoTransacao.Venda;
        int idInvestimento = transacao.InvestimentoId;
        var Investimento = await _investimentoService.ListarInvestimentoId(idInvestimento);
        transacao.NomeInvestimento = Investimento.nome;
        transacao.DataTransacao = DateTime.Now;

        _context.transacao.Add(transacao);
        await _context.SaveChangesAsync();
        return transacao;

    }
}
