using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.App.Management.Infra.Data.Migrations
{
    public partial class adicaodedespesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Despesas",
                table: "Carros",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Despesas",
                table: "Carros");
        }
    }
}
