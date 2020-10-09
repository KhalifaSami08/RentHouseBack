using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class HistoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clientId",
                table: "CommandHistory");

            migrationBuilder.DropColumn(
                name: "propertyId",
                table: "CommandHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "CommandHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "propertyId",
                table: "CommandHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
