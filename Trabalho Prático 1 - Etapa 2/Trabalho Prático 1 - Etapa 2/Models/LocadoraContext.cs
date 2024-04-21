using Microsoft.EntityFrameworkCore;
using Trabalho_Prático_1___Etapa_2.Models;

namespace Trabalho_Prático_1___Etapa_2.Models
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {
        }
        public DbSet<Locadora.Cliente> Clientes { get; set; }
        public DbSet<Locadora.Veiculo> Veiculos { get; set; }
        public DbSet<Locadora.Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Server=localhost;Database=TrabalhoPratico;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
