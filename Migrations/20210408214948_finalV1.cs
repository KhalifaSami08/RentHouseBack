using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class finalV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_CommandProperty_PropertyidProperty",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandProperty",
                table: "CommandProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandContract",
                table: "CommandContract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandClient",
                table: "CommandClient");

            migrationBuilder.DropColumn(
                name: "adress",
                table: "CommandProperty");

            migrationBuilder.DropColumn(
                name: "garanteeAmount",
                table: "CommandContract");

            migrationBuilder.DropColumn(
                name: "adress",
                table: "CommandClient");

            migrationBuilder.RenameTable(
                name: "CommandProperty",
                newName: "commandProperty");

            migrationBuilder.RenameTable(
                name: "CommandContract",
                newName: "commandContract");

            migrationBuilder.RenameTable(
                name: "CommandClient",
                newName: "commandClient");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "commandProperty",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "commandProperty",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "guaranteeAmount",
                table: "commandContract",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "commandClient",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_commandProperty",
                table: "commandProperty",
                column: "idProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_commandContract",
                table: "commandContract",
                column: "idContract");

            migrationBuilder.AddPrimaryKey(
                name: "PK_commandClient",
                table: "commandClient",
                column: "idClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_commandProperty_PropertyidProperty",
                table: "Room",
                column: "PropertyidProperty",
                principalTable: "commandProperty",
                principalColumn: "idProperty",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_commandProperty_PropertyidProperty",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_commandProperty",
                table: "commandProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_commandContract",
                table: "commandContract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_commandClient",
                table: "commandClient");

            migrationBuilder.DropColumn(
                name: "address",
                table: "commandProperty");

            migrationBuilder.DropColumn(
                name: "guaranteeAmount",
                table: "commandContract");

            migrationBuilder.DropColumn(
                name: "address",
                table: "commandClient");

            migrationBuilder.RenameTable(
                name: "commandProperty",
                newName: "CommandProperty");

            migrationBuilder.RenameTable(
                name: "commandContract",
                newName: "CommandContract");

            migrationBuilder.RenameTable(
                name: "commandClient",
                newName: "CommandClient");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "CommandProperty",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "CommandProperty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "garanteeAmount",
                table: "CommandContract",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "adress",
                table: "CommandClient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandProperty",
                table: "CommandProperty",
                column: "idProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandContract",
                table: "CommandContract",
                column: "idContract");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandClient",
                table: "CommandClient",
                column: "idClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_CommandProperty_PropertyidProperty",
                table: "Room",
                column: "PropertyidProperty",
                principalTable: "CommandProperty",
                principalColumn: "idProperty",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
