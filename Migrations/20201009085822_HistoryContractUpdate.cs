using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class HistoryContractUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandHistory");

            migrationBuilder.AddColumn<bool>(
                name: "isCurrentlyRented",
                table: "CommandProp",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CommandContr",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCurrentlyRented",
                table: "CommandProp");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CommandContr");

            migrationBuilder.CreateTable(
                name: "CommandHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    beginContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contractId = table.Column<int>(type: "int", nullable: false),
                    endContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCurrentlyRented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandHistory", x => x.id);
                });
        }
    }
}
