using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class constps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionEntityStopEntity");

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Stops");

            migrationBuilder.AddColumn<Guid>(
                name: "CarrierId",
                table: "Stops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stops_CarrierId",
                table: "Stops",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stops_Carriers_CarrierId",
                table: "Stops",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stops_Carriers_CarrierId",
                table: "Stops");

            migrationBuilder.DropIndex(
                name: "IX_Stops_CarrierId",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Stops");

            migrationBuilder.AddColumn<Guid>(
                name: "ConnectionId",
                table: "Stops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_ConnectionEntityStopEntity_StopsId",
                table: "ConnectionEntityStopEntity",
                column: "StopsId");
        }
    }
}
