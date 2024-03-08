using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExercicio.Migrations
{
    /// <inheritdoc />
    public partial class MigraDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "PedidosProdutos",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "PedidosProdutos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "PedidosProdutos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "PedidosProdutos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "PedidosProdutos");

            migrationBuilder.AlterColumn<string>(
                name: "Quantidade",
                table: "PedidosProdutos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);
        }
    }
}
