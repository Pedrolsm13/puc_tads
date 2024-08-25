namespace Introducao_a_APIs.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public int Codigo_de_Pessoa { get; set; }
        public string? Lembrete_de_Senha { get; set; }
        public int Idade { get; set; }
        public string? Sexo { get; set; }
    }
}
