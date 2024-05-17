using AutoMapper;
using portifolioInvestimento.DTOS;
using portifolioInvestimento.Models;
using portifolioInvestimento.Repositories;

namespace portifolioInvestimento.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task CriarUsuario(UsuarioDTO usuarioDTO)
    {
        var entityUsuario = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepository.CriarUsuario(entityUsuario);
    }

    public async Task EditarUsuario(UsuarioDTO usuarioDTO)
    {
        var entityUsuario = _mapper.Map<Usuario>(usuarioDTO);
        await _usuarioRepository.EditarUsuario(entityUsuario);
    }

    public async Task<UsuarioDTO> ListarUsuarioPorId(int id)
    {
        var entityUsuario = await _usuarioRepository.ListarUsuariosPorId(id);
        return _mapper.Map<UsuarioDTO>(entityUsuario);
    }

    public async Task<UsuarioDTO> ListarUsuarioPorNome(string nome)
    {
        var entityUsuario = await _usuarioRepository.ListarUsuariosPorNome(nome);
        return _mapper.Map<UsuarioDTO>(entityUsuario);
    }

    public async Task<IEnumerable<UsuarioDTO>> listarUsuarios()
    {
        var entityUsuario = await _usuarioRepository.ListarUsuarios();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(entityUsuario);
    }

    public async Task RemoverUsuario(int id)
    {
        var entityUsuario = _usuarioRepository.ListarUsuariosPorId(id);


        await _usuarioRepository.RemoverUsuario(entityUsuario.Id);
    }
}
