using Microsoft.EntityFrameworkCore;

namespace Introducao_a_APIs_com_C_.Models
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; } = null!;
    }
}
