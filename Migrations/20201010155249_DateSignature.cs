using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class DateSignature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "signatureDate",
                table: "CommandProperty");

            migrationBuilder.AddColumn<DateTime>(
                name: "signatureDate",
                table: "CommandContract",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "signatureDate",
                table: "CommandContract");

            migrationBuilder.AddColumn<DateTime>(
                name: "signatureDate",
                table: "CommandProperty",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }
    }
}
