namespace portifolioInvestimento.Interfaces;

public interface IEnviadorEmail
{
    Task EnviarEmail(string email, string assunto, string mensagem);
}
