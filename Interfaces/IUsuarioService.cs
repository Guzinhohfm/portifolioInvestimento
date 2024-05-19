using portifolioInvestimento.DTOS;


namespace portifolioInvestimento.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDTO>> listarUsuarios();

    Task<UsuarioDTO> ListarUsuarioPorNome(string nome);

    Task<UsuarioDTO> ListarUsuarioPorId(int id);

    Task<UsuarioDTO> CriarUsuario(UsuarioDTO usuarioDTO);

    Task EditarUsuario(UsuarioDTO usuarioDTO);
    Task RemoverUsuario(int id);

    Task<IEnumerable<UsuarioDTO>> ObterUsuariosAdm();
}
