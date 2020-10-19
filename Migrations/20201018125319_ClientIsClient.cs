using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ClientIsClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "haveGarant",
                table: "CommandClient");

            migrationBuilder.AddColumn<bool>(
                name: "isClient",
                table: "CommandClient",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isClient",
                table: "CommandClient");

            migrationBuilder.AddColumn<bool>(
                name: "haveGarant",
                table: "CommandClient",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
