using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ClientUpdate_phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandCli",
                columns: table => new
                {
                    idClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    civility = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    adress = table.Column<string>(nullable: false),
                    postalCode = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    placeOfBirth = table.Column<string>(nullable: true),
                    nationalRegister = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandCli", x => x.idClient);
                });

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
                    signatureDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    description = table.Column<string>(nullable: true),
                    nbRoom = table.Column<byte>(nullable: false),
                    totalArea = table.Column<int>(nullable: false),
                    diningRoomArea = table.Column<int>(nullable: false),
                    kitchenArea = table.Column<int>(nullable: false),
                    imageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandProp", x => x.idProperty);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    idRoom = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyidProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.idRoom);
                    table.ForeignKey(
                        name: "FK_Room_CommandProp_PropertyidProperty",
                        column: x => x.PropertyidProperty,
                        principalTable: "CommandProp",
                        principalColumn: "idProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_PropertyidProperty",
                table: "Room",
                column: "PropertyidProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandCli");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "CommandProp");
        }
    }
}
