﻿using AutoMapper;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Interfaces;
using portifolioInvestimento.Models;


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

    public async Task<IEnumerable<InvestimentoDTO>> ListarInvestimentos(int skip, int take)
    {
        var investimentoEntity = await _investimentoRepository.ListarInvestimentos(skip, take);
        return _mapper.Map<IEnumerable<InvestimentoDTO>>(investimentoEntity);
    }

    public async Task DesativarInvestimento(int id)
    {
        var investimentoEntity = await _investimentoRepository.DesativarInvestimento(id);
        await _investimentoRepository.EditarInvestimento(investimentoEntity);

    }

}
