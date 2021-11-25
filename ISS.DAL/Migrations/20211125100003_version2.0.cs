using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class version20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_VehicleEntity_CarrierId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Carriers_CarrierId",
                table: "Emploees");

            migrationBuilder.DropColumn(
                name: "NumberOfReservedSeats",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Emploees");

            migrationBuilder.RenameColumn(
                name: "CarrierId",
                table: "Emploees",
                newName: "ConnectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Emploees_CarrierId",
                table: "Emploees",
                newName: "IX_Emploees_ConnectionId");

            migrationBuilder.AddColumn<Guid>(
                name: "CarrierEntityId",
                table: "VehicleEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "VehicleEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TravelClass",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ConnectionEntityStopEntity",
                columns: table => new
                {
                    ConnectionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StopsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionEntityStopEntity", x => new { x.ConnectionsId, x.StopsId });
                    table.ForeignKey(
                        name: "FK_ConnectionEntityStopEntity_Connections_ConnectionsId",
                        column: x => x.ConnectionsId,
                        principalTable: "Connections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectionEntityStopEntity_Stops_StopsId",
                        column: x => x.StopsId,
                        principalTable: "Stops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEntity_CarrierEntityId",
                table: "VehicleEntity",
                column: "CarrierEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_VehicleId",
                table: "Connections",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionEntityStopEntity_StopsId",
                table: "ConnectionEntityStopEntity",
                column: "StopsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_VehicleEntity_VehicleId",
                table: "Connections",
                column: "VehicleId",
                principalTable: "VehicleEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Carriers_ConnectionId",
                table: "Emploees",
                column: "ConnectionId",
                principalTable: "Carriers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_Carriers_CarrierEntityId",
                table: "VehicleEntity",
                column: "CarrierEntityId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_VehicleEntity_VehicleId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Carriers_ConnectionId",
                table: "Emploees");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_Carriers_CarrierEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropTable(
                name: "ConnectionEntityStopEntity");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEntity_CarrierEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropIndex(
                name: "IX_Connections_VehicleId",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "CarrierEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "VehicleEntity");

            migrationBuilder.RenameColumn(
                name: "ConnectionId",
                table: "Emploees",
                newName: "CarrierId");

            migrationBuilder.RenameIndex(
                name: "IX_Emploees_ConnectionId",
                table: "Emploees",
                newName: "IX_Emploees_CarrierId");

            migrationBuilder.AlterColumn<int>(
                name: "TravelClass",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfReservedSeats",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Emploees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_VehicleEntity_CarrierId",
                table: "Connections",
                column: "CarrierId",
                principalTable: "VehicleEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Carriers_CarrierId",
                table: "Emploees",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }
    }
}
