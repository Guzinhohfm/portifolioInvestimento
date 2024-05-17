using AutoMapper;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.DTOS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Investimento, InvestimentoDTO>().ReverseMap();
            CreateMap<Transacao, TransacaoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
