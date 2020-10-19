using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ContractAddClientEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "floor",
                table: "CommandProperty",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idProprio",
                table: "CommandProperty",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idProprio",
                table: "CommandProperty");

            migrationBuilder.AlterColumn<byte>(
                name: "floor",
                table: "CommandProperty",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte));
        }
    }
}
