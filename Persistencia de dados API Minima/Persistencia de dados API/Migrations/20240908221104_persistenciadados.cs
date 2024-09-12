using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia_de_dados_API.Migrations
{
    /// <inheritdoc />
    public partial class persistenciadados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo_Produto = table.Column<int>(type: "int", nullable: false),
                    Preco_Produto = table.Column<double>(type: "float", nullable: false),
                    Descricao_Produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade_Estoque = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
