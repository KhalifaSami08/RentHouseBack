using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_RentHouse_Khalifa_Sami.Migrations
{
    public partial class ConfigureGraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "commandProperty",
                newName: "CommandProperty");

            migrationBuilder.RenameTable(
                name: "commandContract",
                newName: "CommandContract");

            migrationBuilder.RenameTable(
                name: "commandClient",
                newName: "CommandClient");

            migrationBuilder.RenameColumn(
                name: "PropertyidProperty",
                table: "Room",
                newName: "PropertyIdProperty");

            migrationBuilder.RenameColumn(
                name: "idRoom",
                table: "Room",
                newName: "IdRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Room_PropertyidProperty",
                table: "Room",
                newName: "IX_Room_PropertyIdProperty");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "CommandProperty",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "totalArea",
                table: "CommandProperty",
                newName: "TotalArea");

            migrationBuilder.RenameColumn(
                name: "rentCost",
                table: "CommandProperty",
                newName: "RentCost");

            migrationBuilder.RenameColumn(
                name: "nbRoom",
                table: "CommandProperty",
                newName: "NbRoom");

            migrationBuilder.RenameColumn(
                name: "nbLocator",
                table: "CommandProperty",
                newName: "NbLocator");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "CommandProperty",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "CommandProperty",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "kitchenArea",
                table: "CommandProperty",
                newName: "KitchenArea");

            migrationBuilder.RenameColumn(
                name: "imageLink",
                table: "CommandProperty",
                newName: "ImageLink");

            migrationBuilder.RenameColumn(
                name: "idProprio",
                table: "CommandProperty",
                newName: "IdProprio");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "CommandProperty",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "fixedChargesCost",
                table: "CommandProperty",
                newName: "FixedChargesCost");

            migrationBuilder.RenameColumn(
                name: "diningRoomArea",
                table: "CommandProperty",
                newName: "DiningRoomArea");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "CommandProperty",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "CommandProperty",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "idProperty",
                table: "CommandProperty",
                newName: "IdProperty");

            migrationBuilder.RenameColumn(
                name: "signatureDate",
                table: "CommandContract",
                newName: "SignatureDate");

            migrationBuilder.RenameColumn(
                name: "releaseDate",
                table: "CommandContract",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "propertyId",
                table: "CommandContract",
                newName: "PropertyId");

            migrationBuilder.RenameColumn(
                name: "isGuaranteePaid",
                table: "CommandContract",
                newName: "IsGuaranteePaid");

            migrationBuilder.RenameColumn(
                name: "isFirstMountPaid",
                table: "CommandContract",
                newName: "IsFirstMountPaid");

            migrationBuilder.RenameColumn(
                name: "guaranteeAmount",
                table: "CommandContract",
                newName: "GuaranteeAmount");

            migrationBuilder.RenameColumn(
                name: "garanteePaidDate",
                table: "CommandContract",
                newName: "GaranteePaidDate");

            migrationBuilder.RenameColumn(
                name: "entryDate",
                table: "CommandContract",
                newName: "EntryDate");

            migrationBuilder.RenameColumn(
                name: "endIndexWater",
                table: "CommandContract",
                newName: "EndIndexWater");

            migrationBuilder.RenameColumn(
                name: "endIndexGaz",
                table: "CommandContract",
                newName: "EndIndexGaz");

            migrationBuilder.RenameColumn(
                name: "endIndexElectricity",
                table: "CommandContract",
                newName: "EndIndexElectricity");

            migrationBuilder.RenameColumn(
                name: "endContract",
                table: "CommandContract",
                newName: "EndContract");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "CommandContract",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "CommandContract",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "beginIndexWater",
                table: "CommandContract",
                newName: "BeginIndexWater");

            migrationBuilder.RenameColumn(
                name: "beginIndexGaz",
                table: "CommandContract",
                newName: "BeginIndexGaz");

            migrationBuilder.RenameColumn(
                name: "beginIndexElectricity",
                table: "CommandContract",
                newName: "BeginIndexElectricity");

            migrationBuilder.RenameColumn(
                name: "beginContract",
                table: "CommandContract",
                newName: "BeginContract");

            migrationBuilder.RenameColumn(
                name: "baseIndex",
                table: "CommandContract",
                newName: "BaseIndex");

            migrationBuilder.RenameColumn(
                name: "idContract",
                table: "CommandContract",
                newName: "IdContract");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "CommandClient",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "CommandClient",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "placeOfBirth",
                table: "CommandClient",
                newName: "PlaceOfBirth");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "CommandClient",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "nationalRegister",
                table: "CommandClient",
                newName: "NationalRegister");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CommandClient",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isClient",
                table: "CommandClient",
                newName: "IsClient");

            migrationBuilder.RenameColumn(
                name: "haveAlreadyRentedHouse",
                table: "CommandClient",
                newName: "HaveAlreadyRentedHouse");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "CommandClient",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "CommandClient",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dateOfBirth",
                table: "CommandClient",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "CommandClient",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "civility",
                table: "CommandClient",
                newName: "Civility");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "CommandClient",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "CommandClient",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "CommandClient",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "idClient",
                table: "CommandClient",
                newName: "IdClient");

            migrationBuilder.AddColumn<int>(
                name: "IdContract",
                table: "CommandProperty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdContract",
                table: "CommandClient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandProperty",
                table: "CommandProperty",
                column: "IdProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandContract",
                table: "CommandContract",
                column: "IdContract");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandClient",
                table: "CommandClient",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_ClientId",
                table: "CommandContract",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_PropertyId",
                table: "CommandContract",
                column: "PropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandContract_CommandClient_ClientId",
                table: "CommandContract",
                column: "ClientId",
                principalTable: "CommandClient",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandContract_CommandProperty_PropertyId",
                table: "CommandContract",
                column: "PropertyId",
                principalTable: "CommandProperty",
                principalColumn: "IdProperty",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_CommandProperty_PropertyIdProperty",
                table: "Room",
                column: "PropertyIdProperty",
                principalTable: "CommandProperty",
                principalColumn: "IdProperty",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandContract_CommandClient_ClientId",
                table: "CommandContract");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandContract_CommandProperty_PropertyId",
                table: "CommandContract");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_CommandProperty_PropertyIdProperty",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandProperty",
                table: "CommandProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandContract",
                table: "CommandContract");

            migrationBuilder.DropIndex(
                name: "IX_CommandContract_ClientId",
                table: "CommandContract");

            migrationBuilder.DropIndex(
                name: "IX_CommandContract_PropertyId",
                table: "CommandContract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandClient",
                table: "CommandClient");

            migrationBuilder.DropColumn(
                name: "IdContract",
                table: "CommandProperty");

            migrationBuilder.DropColumn(
                name: "IdContract",
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

            migrationBuilder.RenameColumn(
                name: "PropertyIdProperty",
                table: "Room",
                newName: "PropertyidProperty");

            migrationBuilder.RenameColumn(
                name: "IdRoom",
                table: "Room",
                newName: "idRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Room_PropertyIdProperty",
                table: "Room",
                newName: "IX_Room_PropertyidProperty");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "commandProperty",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "TotalArea",
                table: "commandProperty",
                newName: "totalArea");

            migrationBuilder.RenameColumn(
                name: "RentCost",
                table: "commandProperty",
                newName: "rentCost");

            migrationBuilder.RenameColumn(
                name: "NbRoom",
                table: "commandProperty",
                newName: "nbRoom");

            migrationBuilder.RenameColumn(
                name: "NbLocator",
                table: "commandProperty",
                newName: "nbLocator");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "commandProperty",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "commandProperty",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "KitchenArea",
                table: "commandProperty",
                newName: "kitchenArea");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "commandProperty",
                newName: "imageLink");

            migrationBuilder.RenameColumn(
                name: "IdProprio",
                table: "commandProperty",
                newName: "idProprio");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "commandProperty",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "FixedChargesCost",
                table: "commandProperty",
                newName: "fixedChargesCost");

            migrationBuilder.RenameColumn(
                name: "DiningRoomArea",
                table: "commandProperty",
                newName: "diningRoomArea");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "commandProperty",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "commandProperty",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "IdProperty",
                table: "commandProperty",
                newName: "idProperty");

            migrationBuilder.RenameColumn(
                name: "SignatureDate",
                table: "commandContract",
                newName: "signatureDate");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "commandContract",
                newName: "releaseDate");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "commandContract",
                newName: "propertyId");

            migrationBuilder.RenameColumn(
                name: "IsGuaranteePaid",
                table: "commandContract",
                newName: "isGuaranteePaid");

            migrationBuilder.RenameColumn(
                name: "IsFirstMountPaid",
                table: "commandContract",
                newName: "isFirstMountPaid");

            migrationBuilder.RenameColumn(
                name: "GuaranteeAmount",
                table: "commandContract",
                newName: "guaranteeAmount");

            migrationBuilder.RenameColumn(
                name: "GaranteePaidDate",
                table: "commandContract",
                newName: "garanteePaidDate");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "commandContract",
                newName: "entryDate");

            migrationBuilder.RenameColumn(
                name: "EndIndexWater",
                table: "commandContract",
                newName: "endIndexWater");

            migrationBuilder.RenameColumn(
                name: "EndIndexGaz",
                table: "commandContract",
                newName: "endIndexGaz");

            migrationBuilder.RenameColumn(
                name: "EndIndexElectricity",
                table: "commandContract",
                newName: "endIndexElectricity");

            migrationBuilder.RenameColumn(
                name: "EndContract",
                table: "commandContract",
                newName: "endContract");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "commandContract",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "commandContract",
                newName: "clientId");

            migrationBuilder.RenameColumn(
                name: "BeginIndexWater",
                table: "commandContract",
                newName: "beginIndexWater");

            migrationBuilder.RenameColumn(
                name: "BeginIndexGaz",
                table: "commandContract",
                newName: "beginIndexGaz");

            migrationBuilder.RenameColumn(
                name: "BeginIndexElectricity",
                table: "commandContract",
                newName: "beginIndexElectricity");

            migrationBuilder.RenameColumn(
                name: "BeginContract",
                table: "commandContract",
                newName: "beginContract");

            migrationBuilder.RenameColumn(
                name: "BaseIndex",
                table: "commandContract",
                newName: "baseIndex");

            migrationBuilder.RenameColumn(
                name: "IdContract",
                table: "commandContract",
                newName: "idContract");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "commandClient",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "commandClient",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "PlaceOfBirth",
                table: "commandClient",
                newName: "placeOfBirth");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "commandClient",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "NationalRegister",
                table: "commandClient",
                newName: "nationalRegister");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "commandClient",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsClient",
                table: "commandClient",
                newName: "isClient");

            migrationBuilder.RenameColumn(
                name: "HaveAlreadyRentedHouse",
                table: "commandClient",
                newName: "haveAlreadyRentedHouse");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "commandClient",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "commandClient",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "commandClient",
                newName: "dateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "commandClient",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Civility",
                table: "commandClient",
                newName: "civility");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "commandClient",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "commandClient",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "commandClient",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "commandClient",
                newName: "idClient");

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
    }
}
