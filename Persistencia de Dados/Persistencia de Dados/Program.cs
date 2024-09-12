using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Persistencia_de_Dados.Program;

namespace Persistencia_de_Dados
{
    internal class Program
    {
        public class Categoria
        {
            [Key]
            public int Id { get; set; }
            public string? Nome { get; set; }
            public ICollection<Produto> Produtos { get; set; }
        }
        public class Produto
        {
            [Key]
            public int Id { get; set; }
            public string? Nome { get; set; }
            public double Preco { get; set; }
            public string? Descricao { get; set; }
            public int Estoque { get; set; }
            public int Avaliacao { get; set; }
            public int CategoriaID { get; set; }
            [ForeignKey("CategoriaID")]
            public string? Categoria { get; set; }
        }
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                _ = optionsBuilder.UseSqlServer(@"Server=localhost;Database=Persistencia;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                // Criando uma nova categoria
                var categoria = new Categoria()
                {
                    Nome = "Eletrônicos"
                };
                context.Categorias.Add(categoria);
                context.SaveChanges();

                // Criando um novo produto e associando-o à categoria criada
                var produto = new Produto()
                {
                    Nome = "Smartphone",
                    Preco = 1200.50,
                    Descricao = "Smartphone com 128GB de armazenamento",
                    Estoque = 50,
                    Avaliacao = 4,
                    CategoriaID = categoria.Id
                };
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }
    }
}
