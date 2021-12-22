using Microsoft.EntityFrameworkCore.Migrations;

namespace GaziLibrary.Migrations
{
    public partial class UpdateMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Messages",
                type: "NUMBER(1)",
                nullable: true,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Messages");
        }
    }
}
