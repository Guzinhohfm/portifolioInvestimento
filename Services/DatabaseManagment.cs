using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Configuration;

namespace portifolioInvestimento.Services;

public static class DatabaseManagment
{
    public static void MigrationInitialization(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var serviceDb = serviceScope.ServiceProvider.GetService<PortifolioDbContext>();

            serviceDb.Database.Migrate(); //Gerar a migração pendente do banco de dados, criando tabelas caso não existam
        }
    }
     
}
