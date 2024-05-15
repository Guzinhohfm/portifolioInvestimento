using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portifolioInvestimento.Migrations
{
    /// <inheritdoc />
    public partial class alterandoNomeTabelaClienteUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_investimentos_clientes_UsuarioId",
                table: "investimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_investimentos_usuarios_UsuarioId",
                table: "investimentos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_investimentos_usuarios_UsuarioId",
                table: "investimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_investimentos_clientes_UsuarioId",
                table: "investimentos",
                column: "UsuarioId",
                principalTable: "clientes",
                principalColumn: "Id");
        }
    }
}
