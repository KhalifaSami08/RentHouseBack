using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ClientUpdataGarantOrLocator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "CommandClient");

            migrationBuilder.AddColumn<bool>(
                name: "isGarant",
                table: "CommandClient",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGarant",
                table: "CommandClient");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "CommandClient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
