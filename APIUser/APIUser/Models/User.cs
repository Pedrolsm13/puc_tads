using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIUser.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        [BsonElement("nome")]
        public string nome { get; set; } = null!;
        public string email { get; set; } = null!;
        public string senha { get; set; } = null!;
        public int codigoPessoa { get; set; }
        public string lembreteSenha { get; set; } = null!;
        public int idade { get; set; }
        public string sexo { get; set; } = null!;
    }
}
