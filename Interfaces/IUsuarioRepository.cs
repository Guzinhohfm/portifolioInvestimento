using portifolioInvestimento.Models;

namespace portifolioInvestimento.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> CriarUsuario(Usuario usuario);

        public Task<IEnumerable<Usuario>> ListarUsuarios();

        public Task<Usuario> ListarUsuariosPorNome(string nome);

        public Task<Usuario> ListarUsuariosPorId(int id);

        public Task<Usuario> EditarUsuario(Usuario usuarioEditado);

        public Task<Usuario> RemoverUsuario(int id);
    }
}
