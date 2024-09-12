using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistencia_de_dados_API
{
    public class Todo
    {
        [Key]
        public int id { get; set; }
        public string? Nome_Produto { get; set; }
        public int Codigo_Produto { get; set; }
        public double Preco_Produto { get; set; }
        public string? Descricao_Produto { get; set; }
        public int Quantidade_Estoque { get; set; }
        public int Avaliacao { get; set; }
        public string? Categoria { get; set; }
        public bool IsComplete { get; set; }
    }
}
