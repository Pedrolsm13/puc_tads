using Microsoft.EntityFrameworkCore;
namespace Introducao_a_APIs.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> TodoUsuario { get; set; } = null!;
    }
}
