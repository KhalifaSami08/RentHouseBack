using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class AjoutHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandHistory",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyId = table.Column<int>(nullable: false),
                    clientId = table.Column<int>(nullable: false),
                    contractId = table.Column<int>(nullable: false),
                    isCurrentlyRented = table.Column<bool>(nullable: false),
                    begin = table.Column<DateTime>(nullable: false),
                    end = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandHistory", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandHistory");
        }
    }
}
