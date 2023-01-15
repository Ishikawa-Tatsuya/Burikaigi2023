using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Burikaigi.Server.Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "星",
                table: "魚",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "星",
                table: "魚");
        }
    }
}
