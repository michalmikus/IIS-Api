using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicRelationsContact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOFSeats = table.Column<int>(type: "int", nullable: true),
                    ReservedSeats = table.Column<int>(type: "int", nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connections_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emploees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emploees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emploees_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emploees_Connections_ConnectionEntityId",
                        column: x => x.ConnectionEntityId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stops_Emploees_EmploeeId",
                        column: x => x.EmploeeId,
                        principalTable: "Emploees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelClass = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmingEmploeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoardingStopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DestinationStopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ConnectionEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PassengerEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Connections_ConnectionEntityId",
                        column: x => x.ConnectionEntityId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Emploees_ConfirmingEmploeeId",
                        column: x => x.ConfirmingEmploeeId,
                        principalTable: "Emploees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerEntityId",
                        column: x => x.PassengerEntityId,
                        principalTable: "Passengers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Stops_BoardingStopId",
                        column: x => x.BoardingStopId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Stops_DestinationStopId",
                        column: x => x.DestinationStopId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeOfDeparture = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTables_Connections_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeTables_Stops_StopId",
                        column: x => x.StopId,
                        principalTable: "Stops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_CarrierId",
                table: "Connections",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_CarrierId",
                table: "Emploees",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_ConnectionEntityId",
                table: "Emploees",
                column: "ConnectionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_EmploeeId",
                table: "Stops",
                column: "EmploeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BoardingStopId",
                table: "Tickets",
                column: "BoardingStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConfirmingEmploeeId",
                table: "Tickets",
                column: "ConfirmingEmploeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConnectionEntityId",
                table: "Tickets",
                column: "ConnectionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DestinationStopId",
                table: "Tickets",
                column: "DestinationStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerEntityId",
                table: "Tickets",
                column: "PassengerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ConnectionId",
                table: "TimeTables",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_StopId",
                table: "TimeTables",
                column: "StopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Emploees");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Carriers");
        }
    }
}
