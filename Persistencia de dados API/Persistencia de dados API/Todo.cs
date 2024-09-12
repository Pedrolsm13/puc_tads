using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persistencia_de_dados_API
{
    public class Todo
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
    }
}
