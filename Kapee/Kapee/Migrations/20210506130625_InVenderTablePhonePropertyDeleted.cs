using Microsoft.EntityFrameworkCore.Migrations;

namespace Kapee.Migrations
{
    public partial class InVenderTablePhonePropertyDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Venders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Venders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
