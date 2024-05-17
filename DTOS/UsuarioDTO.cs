using portifolioInvestimento.Models;

namespace portifolioInvestimento.DTOS
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Email { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

    }
}
