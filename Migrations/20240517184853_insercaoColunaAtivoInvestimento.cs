using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portifolioInvestimento.Migrations
{
    /// <inheritdoc />
    public partial class insercaoColunaAtivoInvestimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "investimentos");

            migrationBuilder.RenameColumn(
                name: "validadeProduto",
                table: "investimentos",
                newName: "ValidadeProduto");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "investimentos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "investimentos",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "investimentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "investimentos");

            migrationBuilder.RenameColumn(
                name: "ValidadeProduto",
                table: "investimentos",
                newName: "validadeProduto");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "investimentos",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "investimentos",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "investimentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
