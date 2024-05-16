using Microsoft.EntityFrameworkCore;
using portifolioInvestimento.Models;

namespace portifolioInvestimento.Configuration
{
    public class PortifolioDbContext : DbContext
    {

        public PortifolioDbContext(DbContextOptions<PortifolioDbContext> options) : base(options)
        {
        }

        public DbSet<Investimento> investimentos { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Transacao> transacao { get; set; }

       
    }
}
