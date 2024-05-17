namespace portifolioInvestimento.Models;

public class Usuario : BaseEntity
{
    public string Name { get; set; }

    public string? Email { get; set; }

    public TipoUsuario TipoUsuario { get; set; }

}
