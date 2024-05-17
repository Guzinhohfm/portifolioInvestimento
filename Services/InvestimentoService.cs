using AutoMapper;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Models;
using portifolioInvestimento.Repositories;

namespace portifolioInvestimento.Services;

public class InvestimentoService : IInvestimentoService
{
    private readonly IInvestimentoRepository _investimentoRepository;
    private readonly IMapper _mapper;

    public InvestimentoService(IInvestimentoRepository investimentoRepository, IMapper mapper)
    {
        _investimentoRepository = investimentoRepository;
        _mapper = mapper;
    }

    public async Task<InvestimentoDTO> AdicionarInvestimento(InvestimentoDTO investimentoDTO)
    {
        var investimentoEntity = _mapper.Map<Investimento>(investimentoDTO);
        var investimento = await _investimentoRepository.AdicionarInvestimento(investimentoEntity);


        return _mapper.Map<InvestimentoDTO>(investimento);
         
    }

    public async Task EditarInvestimento(InvestimentoDTO investimentoDTO)
    {
        var investimentoEntity = _mapper.Map<Investimento>(investimentoDTO);
        await _investimentoRepository.EditarInvestimento(investimentoEntity);
    }

    public async Task<InvestimentoDTO> ListarInvestimentoId(int id)
    {
        var investimentoEntity = await _investimentoRepository.ListarInvestimentoId(id);
        return _mapper.Map<InvestimentoDTO>(investimentoEntity);
    }

    public async Task<InvestimentoDTO> ListarInvestimentoNome(string nome)
    {
        var investimentoEntity = await _investimentoRepository.ListarInvestimentosNome(nome);
        return _mapper.Map<InvestimentoDTO>(investimentoEntity);
    }

    public async Task<IEnumerable<InvestimentoDTO>> ListarInvestimentos()
    {
        var investimentoEntity = await _investimentoRepository.ListarInvestimentos();
        return _mapper.Map<IEnumerable<InvestimentoDTO>>(investimentoEntity);
    }

    public async Task RemoverInvestimento(int id)
    {
        var investimentoEntity = await _investimentoRepository.ListarInvestimentoId(id);


        await _investimentoRepository.RemoverInvestimento(investimentoEntity.id);
    }
}
