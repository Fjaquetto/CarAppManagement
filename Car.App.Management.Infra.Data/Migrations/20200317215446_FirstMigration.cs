using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.App.Management.Infra.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime", nullable: false),
                    Placa = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ValorComprado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime", nullable: true),
                    IpvaPago = table.Column<bool>(type: "bit", nullable: false),
                    Vendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
