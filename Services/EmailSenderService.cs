using MimeKit;
using MailKit.Net.Smtp;
using portifolioInvestimento.Interfaces;

namespace portifolioInvestimento.Services
{
    public class EmailSenderService : BackgroundService
    {
        private readonly ILogger<EmailSenderService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public EmailSenderService(ILogger<EmailSenderService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var nextRunTime = now.Date.AddDays(1); // Programado para dia seguinte 
                var delay = nextRunTime - now;
                _logger.LogInformation("E-mail diário será enviado: {delay}", delay);

                if (delay > TimeSpan.Zero)
                    await Task.Delay(delay, stoppingToken);

                using (var scope = _serviceProvider.CreateScope())
                {
                    int skip = 0;
                    int take = 50;
                    var investimentoService = scope.ServiceProvider.GetRequiredService<IInvestimentoService>();
                    var produtos = await investimentoService.
                        ListarInvestimentos(skip, take);
                    
                    var auxProdutos = produtos.Where(x => x.validadeProduto.AddDays(3).Day == now.Day).Select(x => x.nome).ToList();

                    if (auxProdutos != null) 
                    {
                        await SendEmailAsync(stoppingToken, auxProdutos);
                        _logger.LogInformation("E-mail enviado: {time}", DateTime.Now);
                    }
                    else
                    {
                        _logger.LogInformation("E-mail não enviado pois não há produtos vencendo: {time}", DateTime.Now);
                    }
                    
                }
                  
               
            }
        }

        private async Task SendEmailAsync(CancellationToken stoppingToken, IEnumerable<string> produtos)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<IUsuarioService>();
                var usuariosAdm = await userService.ObterUsuariosAdm();
                var emails = usuariosAdm.
                    Where(x => x.TipoUsuario == Models.TipoUsuario.Administrador).
                    Select(x => x.Email).ToList();

                var senhaAutenticacao = "teste@123";

                string body = "";
                
                foreach (string item in produtos)
                {
                    body +=  item + ", ";
                }

                foreach (var email in emails)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Sistema", "testeapiinvestimento@gmail.com"));
                    message.To.Add(new MailboxAddress("", email));
                    message.Subject = "Lembrete diário de produtos com vencimento próximo";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Informamos que os produtos: " + body + "estão para vencer"
                    };

                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls, stoppingToken);
                        await client.AuthenticateAsync("testeapiinvestimento@gmail.com", senhaAutenticacao);
                        await client.SendAsync(message, stoppingToken);
                        await client.DisconnectAsync(true, stoppingToken);
                    }
                }
            }
        }
    }
}

