using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class HandleHistoryDebug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandContr",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CommandContr");

            migrationBuilder.RenameTable(
                name: "CommandContr",
                newName: "Contract");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "idContract");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "CommandContr");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CommandContr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandContr",
                table: "CommandContr",
                column: "idContract");
        }
    }
}
