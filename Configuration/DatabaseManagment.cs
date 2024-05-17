using Microsoft.EntityFrameworkCore;

namespace portifolioInvestimento.Configuration;

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
