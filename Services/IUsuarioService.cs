using portifolioInvestimento.DTOS;

namespace portifolioInvestimento.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> listarUsuarios();

    Task<UsuarioDTO> ListarUsuarioPorNome(string nome);

    Task<UsuarioDTO> ListarUsuarioPorId(int id);

    Task CriarUsuario(UsuarioDTO usuarioDTO);

    Task EditarUsuario(UsuarioDTO usuarioDTO);
    Task RemoverUsuario(int id);
}
