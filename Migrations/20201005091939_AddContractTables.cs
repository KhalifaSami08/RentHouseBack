using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class AddContractTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "CommandCli",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.CreateTable(
                name: "CommandContr",
                columns: table => new
                {
                    idContract = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adress = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    floor = table.Column<byte>(nullable: true),
                    rentCost = table.Column<float>(nullable: false),
                    fixedChargesCost = table.Column<float>(nullable: false),
                    signatureDate = table.Column<DateTime>(nullable: false),
                    propertyId = table.Column<int>(nullable: false),
                    clientId = table.Column<int>(nullable: false),
                    begin = table.Column<DateTime>(nullable: false),
                    end = table.Column<DateTime>(nullable: false),
                    duration = table.Column<byte>(nullable: false),
                    baseIndex = table.Column<byte>(nullable: false),
                    garanteeAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandContr", x => x.idContract);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandContr");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "CommandCli",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
