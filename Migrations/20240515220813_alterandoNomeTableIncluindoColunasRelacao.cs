using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portifolioInvestimento.Migrations
{
    /// <inheritdoc />
    public partial class alterandoNomeTableIncluindoColunasRelacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestimentoId",
                table: "clientes");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "investimentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "validadeProduto",
                table: "investimentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_investimentos_UsuarioId",
                table: "investimentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_investimentos_clientes_UsuarioId",
                table: "investimentos",
                column: "UsuarioId",
                principalTable: "clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_investimentos_clientes_UsuarioId",
                table: "investimentos");

            migrationBuilder.DropIndex(
                name: "IX_investimentos_UsuarioId",
                table: "investimentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "investimentos");

            migrationBuilder.DropColumn(
                name: "validadeProduto",
                table: "investimentos");

            migrationBuilder.AddColumn<int>(
                name: "InvestimentoId",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
