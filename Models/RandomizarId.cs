namespace portifolioInvestimento.Models;

public class RandomizarId
{
    public static string GerarIdUnico()
    {
        return Guid.NewGuid().ToString();
    }
}
