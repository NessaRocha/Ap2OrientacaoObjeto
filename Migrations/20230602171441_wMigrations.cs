using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoPooBanco.Migrations
{
    /// <inheritdoc />
    public partial class wMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transacoes",
                newName: "IdDeposito");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transacoes",
                newName: "IdTransacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDeposito",
                table: "Transacoes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdTransacao",
                table: "Transacoes",
                newName: "Id");
        }
    }
}
