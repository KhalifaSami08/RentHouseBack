using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class deleteHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_CommandProp_PropertyidProperty",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandProp",
                table: "CommandProp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandCli",
                table: "CommandCli");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CommandContract");

            migrationBuilder.RenameTable(
                name: "CommandProp",
                newName: "CommandProperty");

            migrationBuilder.RenameTable(
                name: "CommandCli",
                newName: "CommandClient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandProperty",
                table: "CommandProperty",
                column: "idProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandClient",
                table: "CommandClient",
                column: "idClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_CommandProperty_PropertyidProperty",
                table: "Room",
                column: "PropertyidProperty",
                principalTable: "CommandProperty",
                principalColumn: "idProperty",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_CommandProperty_PropertyidProperty",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandProperty",
                table: "CommandProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandClient",
                table: "CommandClient");

            migrationBuilder.RenameTable(
                name: "CommandProperty",
                newName: "CommandProp");

            migrationBuilder.RenameTable(
                name: "CommandClient",
                newName: "CommandCli");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CommandContract",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandProp",
                table: "CommandProp",
                column: "idProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandCli",
                table: "CommandCli",
                column: "idClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_CommandProp_PropertyidProperty",
                table: "Room",
                column: "PropertyidProperty",
                principalTable: "CommandProp",
                principalColumn: "idProperty",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
