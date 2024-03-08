using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExercicio.Migrations
{
    /// <inheritdoc />
    public partial class MigDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: true),
                    CategoriasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_CategoriasId",
                table: "PedidosProdutos",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_ProdutosId",
                table: "PedidosProdutos",
                column: "ProdutosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
