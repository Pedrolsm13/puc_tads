using Microsoft.EntityFrameworkCore;
using static Persistencia_de_dados_API.Todo;

namespace Persistencia_de_dados_API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Server=localhost;Database=Persistencia;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
