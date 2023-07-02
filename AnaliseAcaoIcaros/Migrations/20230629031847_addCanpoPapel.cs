using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnaliseAcaoIcaros.Migrations
{
    public partial class addCanpoPapel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "Papels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Setor",
                table: "Papels");
        }
    }
}
