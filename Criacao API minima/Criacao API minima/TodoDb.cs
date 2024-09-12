using Microsoft.EntityFrameworkCore;

namespace Criacao_API_minima
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) :
            base(options)
        { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
