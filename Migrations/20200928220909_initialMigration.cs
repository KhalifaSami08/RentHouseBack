using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandProp",
                columns: table => new
                {
                    idProperty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adress = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    floor = table.Column<byte>(nullable: true),
                    rentCost = table.Column<float>(nullable: false),
                    fixedChargesCost = table.Column<float>(nullable: false),
                    signatureDate = table.Column<DateTime>(nullable: false),
                    nbRoom = table.Column<byte>(nullable: false),
                    totalArea = table.Column<int>(nullable: false),
                    diningRoomArea = table.Column<int>(nullable: false),
                    kitchenArea = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandProp", x => x.idProperty);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandProp");
        }
    }
}
