using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnaliseAcaoIcaros.Migrations
{
    public partial class addRelacionamentoCarteiraPapel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdCarteira",
                table: "Papels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Papels_IdCarteira",
                table: "Papels",
                column: "IdCarteira");

            migrationBuilder.AddForeignKey(
                name: "FK_Papels_Carteiras_IdCarteira",
                table: "Papels",
                column: "IdCarteira",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Papels_Carteiras_IdCarteira",
                table: "Papels");

            migrationBuilder.DropIndex(
                name: "IX_Papels_IdCarteira",
                table: "Papels");

            migrationBuilder.DropColumn(
                name: "IdCarteira",
                table: "Papels");
        }
    }
}
