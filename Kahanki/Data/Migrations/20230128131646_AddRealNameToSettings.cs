using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kahanki.Data.Migrations
{
    public partial class AddRealNameToSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealName",
                table: "UserSettings");
        }
    }
}
