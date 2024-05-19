using AutoMapper;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Interfaces;
using portifolioInvestimento.Models;
using portifolioInvestimento.Repositories;

namespace portifolioInvestimento.Services;

public class TransacaoService : ITransacaoService
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IMapper _mapper;

    public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper)
    {
        _transacaoRepository = transacaoRepository;
        _mapper = mapper;
    }

    public async Task Comprar(TransacaoDTO transacaoDTO)
    {
        var transacaoEntity = _mapper.Map<Transacao>(transacaoDTO);
        await _transacaoRepository.Comprar(transacaoEntity);
    }

    public async Task Vender(TransacaoDTO transacaoDTO)
    {
        var transacaoEntity = _mapper.Map<Transacao>(transacaoDTO);
        await _transacaoRepository.Vender(transacaoEntity);
    }

    public async Task<IEnumerable<TransacaoDTO>> GerarExtratoPorInvestimento(int investimentoId, int clientId, int skip, int take)
    {
        var extratoEntity = await _transacaoRepository.GerarExtratoPorInvestimento(investimentoId, clientId, skip, take);
        return _mapper.Map<IEnumerable<TransacaoDTO>>(extratoEntity);
    }

    public async Task<IEnumerable<TransacaoDTO>> GerarExtratoTotalCliente(int clientId, int skip, int take)
    {
        var extratoEntity = await _transacaoRepository.GerarExtratoTotalCliente(clientId, skip, take);
        return _mapper.Map<IEnumerable<TransacaoDTO>>(extratoEntity);
    }
}
