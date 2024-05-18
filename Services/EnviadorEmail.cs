using System.Net;
using System.Net.Mail;
using portifolioInvestimento.Interfaces;

namespace portifolioInvestimento.Services;

public class EnviadorEmail : IEnviadorEmail
{
    public Task EnviarEmail(string email, string assunto, string mensagem)
    {
        var emailAdm = "g-ferreira-moreira@hotmail.com";
        var senha = "Guliver1224#";

        var client = new SmtpClient()
        {
            Host = "outlook.office365.com",
            Port = 587,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(emailAdm, senha),
            DeliveryMethod = SmtpDeliveryMethod.Network


        };

        return client.SendMailAsync(
            new MailMessage(from: emailAdm, to: email, assunto, mensagem));
    }
}
