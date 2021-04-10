using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ConfigureGraphV13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommandContract_ClientId",
                table: "CommandContract");

            migrationBuilder.DropIndex(
                name: "IX_CommandContract_PropertyId",
                table: "CommandContract");

            migrationBuilder.DropColumn(
                name: "IdContract",
                table: "CommandProperty");

            migrationBuilder.DropColumn(
                name: "IdContract",
                table: "CommandClient");

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_ClientId",
                table: "CommandContract",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_PropertyId",
                table: "CommandContract",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommandContract_ClientId",
                table: "CommandContract");

            migrationBuilder.DropIndex(
                name: "IX_CommandContract_PropertyId",
                table: "CommandContract");

            migrationBuilder.AddColumn<int>(
                name: "IdContract",
                table: "CommandProperty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdContract",
                table: "CommandClient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_ClientId",
                table: "CommandContract",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_PropertyId",
                table: "CommandContract",
                column: "PropertyId",
                unique: true);
        }
    }
}
