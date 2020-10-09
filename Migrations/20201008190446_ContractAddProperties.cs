using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ContractAddProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "begin",
                table: "CommandHistory");

            migrationBuilder.DropColumn(
                name: "end",
                table: "CommandHistory");

            migrationBuilder.DropColumn(
                name: "begin",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "end",
                table: "CommandContr");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "CommandProp",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "beginContract",
                table: "CommandHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "endContract",
                table: "CommandHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "beginContract",
                table: "CommandContr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "beginIndexElectricity",
                table: "CommandContr",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "beginIndexGaz",
                table: "CommandContr",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "beginIndexWater",
                table: "CommandContr",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "endContract",
                table: "CommandContr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "endIndexElectricity",
                table: "CommandContr",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "endIndexGaz",
                table: "CommandContr",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "endIndexWater",
                table: "CommandContr",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "entryDate",
                table: "CommandContr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "garanteePaidDate",
                table: "CommandContr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isFirstMountPaid",
                table: "CommandContr",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isGuaranteePaid",
                table: "CommandContr",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "releaseDate",
                table: "CommandContr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beginContract",
                table: "CommandHistory");

            migrationBuilder.DropColumn(
                name: "endContract",
                table: "CommandHistory");

            migrationBuilder.DropColumn(
                name: "beginContract",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "beginIndexElectricity",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "beginIndexGaz",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "beginIndexWater",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "endContract",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "endIndexElectricity",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "endIndexGaz",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "endIndexWater",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "entryDate",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "garanteePaidDate",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "isFirstMountPaid",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "isGuaranteePaid",
                table: "CommandContr");

            migrationBuilder.DropColumn(
                name: "releaseDate",
                table: "CommandContr");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "CommandProp",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "begin",
                table: "CommandHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "end",
                table: "CommandHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "begin",
                table: "CommandContr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "end",
                table: "CommandContr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
