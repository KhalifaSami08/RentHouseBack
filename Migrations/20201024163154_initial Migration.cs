using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandClient",
                columns: table => new
                {
                    idClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    civility = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    adress = table.Column<string>(nullable: false),
                    postalCode = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: false),
                    isClient = table.Column<bool>(nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    placeOfBirth = table.Column<string>(nullable: true),
                    nationalRegister = table.Column<string>(nullable: true),
                    haveAlreadyRentedHouse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandClient", x => x.idClient);
                });

            migrationBuilder.CreateTable(
                name: "CommandContract",
                columns: table => new
                {
                    idContract = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyId = table.Column<int>(nullable: false),
                    clientId = table.Column<int>(nullable: false),
                    beginContract = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    endContract = table.Column<DateTime>(nullable: false),
                    duration = table.Column<byte>(nullable: false),
                    baseIndex = table.Column<byte>(nullable: false),
                    garanteeAmount = table.Column<float>(nullable: false),
                    signatureDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    beginIndexWater = table.Column<float>(nullable: false),
                    beginIndexGaz = table.Column<float>(nullable: false),
                    beginIndexElectricity = table.Column<float>(nullable: false),
                    isGuaranteePaid = table.Column<bool>(nullable: false),
                    garanteePaidDate = table.Column<DateTime>(nullable: false),
                    isFirstMountPaid = table.Column<bool>(nullable: false),
                    entryDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    releaseDate = table.Column<DateTime>(nullable: false),
                    endIndexWater = table.Column<float>(nullable: false),
                    endIndexGaz = table.Column<float>(nullable: false),
                    endIndexElectricity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandContract", x => x.idContract);
                });

            migrationBuilder.CreateTable(
                name: "CommandProperty",
                columns: table => new
                {
                    idProperty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: false),
                    adress = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    floor = table.Column<byte>(nullable: false),
                    rentCost = table.Column<float>(nullable: false),
                    fixedChargesCost = table.Column<float>(nullable: false),
                    nbRoom = table.Column<byte>(nullable: false),
                    totalArea = table.Column<int>(nullable: false),
                    diningRoomArea = table.Column<int>(nullable: false),
                    kitchenArea = table.Column<int>(nullable: false),
                    imageLink = table.Column<string>(nullable: true),
                    nbLocator = table.Column<int>(nullable: false),
                    idProprio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandProperty", x => x.idProperty);
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
                        name: "FK_Room_CommandProperty_PropertyidProperty",
                        column: x => x.PropertyidProperty,
                        principalTable: "CommandProperty",
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
                name: "CommandClient");

            migrationBuilder.DropTable(
                name: "CommandContract");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "CommandProperty");
        }
    }
}
