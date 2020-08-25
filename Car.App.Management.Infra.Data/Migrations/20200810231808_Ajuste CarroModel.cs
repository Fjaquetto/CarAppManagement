using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.App.Management.Infra.Data.Migrations
{
    public partial class AjusteCarroModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Clientes_ClienteId",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Carros",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Clientes_ClienteId",
                table: "Carros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Clientes_ClienteId",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Carros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Clientes_ClienteId",
                table: "Carros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
