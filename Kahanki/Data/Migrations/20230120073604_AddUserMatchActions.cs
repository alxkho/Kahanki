using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kahanki.Data.Migrations
{
    public partial class AddUserMatchActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMatchActions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatchActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMatchActions_AspNetUsers_ActedUserId",
                        column: x => x.ActedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMatchActions_AspNetUsers_TargetUserId",
                        column: x => x.TargetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchActions_ActedUserId",
                table: "UserMatchActions",
                column: "ActedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchActions_TargetUserId",
                table: "UserMatchActions",
                column: "TargetUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMatchActions");
        }
    }
}
