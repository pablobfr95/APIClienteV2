using Microsoft.EntityFrameworkCore.Migrations;

namespace APICliente.Infra.Data.Migrations
{
    public partial class Relacionamento_Cliente_Endereco_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cliente_ClienteId1",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ClienteId1",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId1",
                table: "Endereco",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cliente_ClienteId1",
                table: "Endereco",
                column: "ClienteId1",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
