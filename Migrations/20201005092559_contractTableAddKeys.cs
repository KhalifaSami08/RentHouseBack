using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class contractTableAddKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adress",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "fixedChargesCost",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "floor",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "rentCost",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "signatureDate",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "type",
                table: "CommandContr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "CommandContr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "fixedChargesCost",
                table: "CommandContr",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<byte>(
                name: "floor",
                table: "CommandContr",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "rentCost",
                table: "CommandContr",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "signatureDate",
                table: "CommandContr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "CommandContr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
