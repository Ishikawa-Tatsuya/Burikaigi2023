using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burikaigi.Server.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "食味",
                table: "魚");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "食味",
                table: "魚",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
