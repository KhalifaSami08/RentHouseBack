using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class HandleHistoryDebug4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "CommandContract");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CommandContract",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandContract",
                table: "CommandContract",
                column: "idContract");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandContract",
                table: "CommandContract");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CommandContract");

            migrationBuilder.RenameTable(
                name: "CommandContract",
                newName: "Contract");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "idContract");
        }
    }
}
