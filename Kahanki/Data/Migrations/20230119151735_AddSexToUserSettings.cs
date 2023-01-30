using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kahanki.Data.Migrations
{
    public partial class AddSexToUserSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Preferences",
                table: "UserSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "UserSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preferences",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "UserSettings");
        }
    }
}
