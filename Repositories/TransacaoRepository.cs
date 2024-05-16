using Microsoft.AspNetCore.Http.HttpResults;
using portifolioInvestimento.Configuration;
using portifolioInvestimento.Models;
using portifolioInvestimento.Services;

namespace portifolioInvestimento.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly IInvestimentoService _investimentoService;
    private readonly PortifolioDbContext _context;

    public TransacaoRepository(IInvestimentoService investimentoService, PortifolioDbContext context)
    {
        _investimentoService = investimentoService;
        _context = context;
    }

    public async Task<Transacao> Comprar(Transacao transacao)
    {
        var investimentoNome =  transacao.NomeInvestimento;
        var investimento = await _investimentoService.ListarInvestimentoNome(investimentoNome);
        transacao.ValorTransacao = investimento.valor;
        transacao.DataTransacao = DateTime.Today;
        transacao.TipoTransacao = TipoTransacao.Compra;
        _context.transacao.Add(transacao);
        await _context.SaveChangesAsync();
        return transacao;


    }

    //public Task<Transacao> Vender(Transacao transacao)
    //{
    //    throw new NotImplementedException();
    //}
}
