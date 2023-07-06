using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnaliseAcaoIcaros.Migrations
{
    public partial class paperHandlingSeparation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Papels");

            migrationBuilder.DropColumn(
                name: "Operacao",
                table: "Papels");

            migrationBuilder.DropColumn(
                name: "Qtd",
                table: "Papels");

            migrationBuilder.DropColumn(
                name: "Taxa",
                table: "Papels");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Papels");

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qtd = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Taxa = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    IdPapel = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Papels_IdPapel",
                        column: x => x.IdPapel,
                        principalTable: "Papels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_IdPapel",
                table: "Movimentacao",
                column: "IdPapel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Papels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Operacao",
                table: "Papels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Qtd",
                table: "Papels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Taxa",
                table: "Papels",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Papels",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
