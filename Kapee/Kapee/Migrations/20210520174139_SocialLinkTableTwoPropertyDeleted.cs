using Microsoft.EntityFrameworkCore.Migrations;

namespace Kapee.Migrations
{
    public partial class SocialLinkTableTwoPropertyDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flickr",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "Rss",
                table: "SocialLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flickr",
                table: "SocialLinks",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rss",
                table: "SocialLinks",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
