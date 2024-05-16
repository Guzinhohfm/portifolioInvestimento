namespace portifolioInvestimento.Models;

public class Usuario
{
    public int Id { get; set; }

    public string Name { get; set; }

    public TipoUsuario TipoUsuario { get; set; }

    public ICollection<Investimento> Investimentos { get; set; }

}
