using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class vers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stops_Emploees_EmploeeId",
                table: "Stops");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerEntityId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Stops_EmploeeId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "EmploeeId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "NumberOFSeats",
                table: "Connections");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "PassengerEntityId",
                table: "Tickets",
                newName: "PassangerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PassengerEntityId",
                table: "Tickets",
                newName: "IX_Tickets_PassangerId");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfReservedSeats",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleEmploeeId",
                table: "Stops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Connections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SeatEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    TicketEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatEntity_Tickets_TicketEntityId",
                        column: x => x.TicketEntityId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stops_ResponsibleEmploeeId",
                table: "Stops",
                column: "ResponsibleEmploeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatEntity_TicketEntityId",
                table: "SeatEntity",
                column: "TicketEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_VehicleEntity_CarrierId",
                table: "Connections",
                column: "CarrierId",
                principalTable: "VehicleEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stops_Emploees_ResponsibleEmploeeId",
                table: "Stops",
                column: "ResponsibleEmploeeId",
                principalTable: "Emploees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassangerId",
                table: "Tickets",
                column: "PassangerId",
                principalTable: "Passengers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_VehicleEntity_CarrierId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Stops_Emploees_ResponsibleEmploeeId",
                table: "Stops");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassangerId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "SeatEntity");

            migrationBuilder.DropTable(
                name: "VehicleEntity");

            migrationBuilder.DropIndex(
                name: "IX_Stops_ResponsibleEmploeeId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "NumberOfReservedSeats",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ResponsibleEmploeeId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "PassangerId",
                table: "Tickets",
                newName: "PassengerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PassangerId",
                table: "Tickets",
                newName: "IX_Tickets_PassengerEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "EmploeeId",
                table: "Stops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "NumberOFSeats",
                table: "Connections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleType",
                table: "Connections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stops_EmploeeId",
                table: "Stops",
                column: "EmploeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stops_Emploees_EmploeeId",
                table: "Stops",
                column: "EmploeeId",
                principalTable: "Emploees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerEntityId",
                table: "Tickets",
                column: "PassengerEntityId",
                principalTable: "Passengers",
                principalColumn: "Id");
        }
    }
}
