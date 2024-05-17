using AutoMapper;
using portifolioInvestimento.DTOS;
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

    public async Task<TransacaoDTO> ListarTransacaoNome(string nome)
    {
        var transacaoEntity = await _transacaoRepository.ListarTransacoesNome(nome);
        return _mapper.Map<TransacaoDTO>(transacaoEntity);
    }

    public async Task<IEnumerable<TransacaoDTO>> ListarTransacoes()
    {
        var transacaoEntity = await _transacaoRepository.ListarTransacoes();
        return _mapper.Map<IEnumerable<TransacaoDTO>>(transacaoEntity);
    }

}
