using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TranalhoPratico
{
    internal class Program
    {
        public class Veiculo
        {
            [Key]
            public int VeiculoId { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Ano { get; set; }
            public string Placa { get; set; }
        }

        public class Cliente
        {
            [Key]
            public int ClienteId { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
        }

        public class Reserva
        {
            [Key]
            public int ReservaId { get; set; }
            public int VeiculoId { get; set; }
            public int ClienteId { get; set; }
            public DateTime DataReserva { get; set; }
            public DateTime DataDevolucao { get; set; }



            [ForeignKey("VeiculoId")]
            public virtual Veiculo Veiculo { get; set; }
            [ForeignKey("ClienteId")]
            public virtual Cliente Cliente { get; set; }
        }
        
        public class applicationDbContext : DbContext
        {
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<Reserva> Reservas { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                _ = optionsBuilder.UseSqlServer(@"Server=localhost;Database=TrabalhoPratico;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        static void Main(string[] args)
        {
            using(var context = new applicationDbContext())
            {
                var cliente = new Cliente()
                {
                    Nome = "João",
                    Endereco = "Rua 1"
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();
                var veiculo = new Veiculo()
                {
                    Marca = "Fiat",
                    Modelo = "Uno",
                    Ano = 2020,
                    Placa = "ABC1234"
                };
                context.Veiculos.Add(veiculo);
                context.SaveChanges();
                var reserva = new Reserva()
                {
                    VeiculoId = veiculo.VeiculoId,
                    ClienteId = cliente.ClienteId,
                    DataReserva = DateTime.Now,
                    DataDevolucao = DateTime.Now.AddDays(7)
                };
                context.Reservas.Add(reserva);
                context.SaveChanges();
            }
        }
    }
}
