using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_Prático_1___Etapa_2.Models
{
    public class Locadora
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
    }
}
