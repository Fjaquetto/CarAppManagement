using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.App.Management.Infra.Data.Migrations
{
    public partial class adicaocarros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ano",
                table: "Carros",
                type: "varchar(9)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<decimal>(
                name: "DebitoPendente",
                table: "Carros",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Renavam",
                table: "Carros",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebitoPendente",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "Renavam",
                table: "Carros");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ano",
                table: "Carros",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)");
        }
    }
}
