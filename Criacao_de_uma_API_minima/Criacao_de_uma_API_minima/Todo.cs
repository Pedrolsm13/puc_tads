namespace Criacao_de_uma_API_minima
{
    public class Todo
    {
        public int id { get; set; }
        public string? Nome_Produto { get; set;}
        public int Codigo_Produto { get; set; }
        public double Preco_Produto { get; set; }
        public string? Descricao_Produto { get; set; }
        public int Quantidade_Estoque { get; set; }
        public int Avaliacao { get; set; }
        public string? Categoria { get; set; }
        public bool IsComplete { get; set; }
    }
}
