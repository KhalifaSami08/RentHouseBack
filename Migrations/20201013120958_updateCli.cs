using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class updateCli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommandContract_propertyId",
                table: "CommandContract");

            migrationBuilder.DropColumn(
                name: "isGarant",
                table: "CommandClient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "entryDate",
                table: "CommandContract",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "beginContract",
                table: "CommandContract",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "haveGarant",
                table: "CommandClient",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "haveGarant",
                table: "CommandClient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "entryDate",
                table: "CommandContract",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "beginContract",
                table: "CommandContract",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<bool>(
                name: "isGarant",
                table: "CommandClient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_propertyId",
                table: "CommandContract",
                column: "propertyId",
                unique: true);
        }
    }
}
