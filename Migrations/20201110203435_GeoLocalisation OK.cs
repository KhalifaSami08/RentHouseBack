using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class GeoLocalisationOK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lattitude",
                table: "CommandProperty");

            migrationBuilder.AlterColumn<double>(
                name: "longitude",
                table: "CommandProperty",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "CommandProperty",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "CommandProperty");

            migrationBuilder.AlterColumn<int>(
                name: "longitude",
                table: "CommandProperty",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "lattitude",
                table: "CommandProperty",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
