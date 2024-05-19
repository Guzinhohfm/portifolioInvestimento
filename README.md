<h1 align="center">API portifólio carteira investimento</h1>

## 📖 Sobre:
- Criado **sistema de gestão de portfólio de investimentos** para controle dos produtos comprados e vendidos, gerar extrato das transações

## 🔧 Tecnologias utilizadas:
- [.Net](https://dotnet.microsoft.com/pt-br/)
- [ASP.NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)
- [Docker](https://www.docker.com)
  
## 💻 Requisitos para rodar o projeto:
- Docker desktop
- .Net 8

## ▶️ Como rodar o projeto na sua máquina:

- Rode o comando ```docker compose up```
- Rode o comando ```dotnet run```
- Feito!

## Problemas encontrados no projeto e sua solução:
### Problema 1: 
Ao chamar a requisição para editar dados de um usuário no sistema, um erro de rastramento pelo dbContext era retornado.
### Solução:
- A abordagem utilizada para solucionar esse caso em que a entidade já está sendo rastreada foi desanexar a entidade do contexto e depois atualizando:
```csharp
   public async Task<Usuario> EditarUsuario(Usuario usuarioEditado)
   {
       var usuarioExistente = _context.usuarios.Local.FirstOrDefault(u => u.Id == usuarioEditado.Id);

       if (usuarioExistente != null)
       {
           _context.Entry(usuarioExistente).State = EntityState.Detached;
       }
       _context.Entry(usuarioEditado).State = EntityState.Modified;
       await _context.SaveChangesAsync();
       return usuarioEditado;
   }
```
### Problema 2:
Criar um serviço que iria disparar e-mail diariamente para o usuário administrador.
### Solução:
- Utilização do BackgroundService, que no contexto do .Net Core executa tarefas em segundo plano
### Problema 3:
Um problema enfrentado foi na utilização do background service que iria disparar e-mail diariamente sobre produtos que estão com vencimento próximo, nesse caso é necessário chamar serviço de investimentos que retorna a lista de produtos, porém o serviço possui um 
ciclo de vida scoped, o que impossibilita sua injeção no background service que possui um ciclo de vida singleton.
 ### Solução:
 - Uso do IServiceProvider, dessa forma a instância do serviço scoped é gerada e utilizada dentro do contexto correto:
```csharp
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
     
```    
        

