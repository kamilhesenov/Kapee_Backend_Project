using Microsoft.EntityFrameworkCore.Migrations;

namespace Kapee.Migrations
{
    public partial class FooterLogoTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "FooterLogos",
                newName: "PhotoLogo");

            migrationBuilder.AddColumn<string>(
                name: "PhotoCopyright",
                table: "FooterLogos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoCopyright",
                table: "FooterLogos");

            migrationBuilder.RenameColumn(
                name: "PhotoLogo",
                table: "FooterLogos",
                newName: "Photo");
        }
    }
}
