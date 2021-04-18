using Microsoft.EntityFrameworkCore.Migrations;

namespace Kapee.Migrations
{
    public partial class VenderTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Venders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venders_AppUserId",
                table: "Venders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venders_AspNetUsers_AppUserId",
                table: "Venders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venders_AspNetUsers_AppUserId",
                table: "Venders");

            migrationBuilder.DropIndex(
                name: "IX_Venders_AppUserId",
                table: "Venders");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Venders");
        }
    }
}
