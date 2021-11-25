using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class version34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarrierId",
                table: "Emploees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmploeeConnectionAssigment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConnectionEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploeeConnectionAssigment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploeeConnectionAssigment_Carriers_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "Carriers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmploeeConnectionAssigment_Connections_ConnectionEntityId",
                        column: x => x.ConnectionEntityId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmploeeConnectionAssigment_Emploees_EmploeeId",
                        column: x => x.EmploeeId,
                        principalTable: "Emploees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_CarrierId",
                table: "Emploees",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploeeConnectionAssigment_ConnectionEntityId",
                table: "EmploeeConnectionAssigment",
                column: "ConnectionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploeeConnectionAssigment_ConnectionId",
                table: "EmploeeConnectionAssigment",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploeeConnectionAssigment_EmploeeId",
                table: "EmploeeConnectionAssigment",
                column: "EmploeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Connections_CarrierId",
                table: "Emploees",
                column: "CarrierId",
                principalTable: "Connections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Connections_CarrierId",
                table: "Emploees");

            migrationBuilder.DropTable(
                name: "EmploeeConnectionAssigment");

            migrationBuilder.DropIndex(
                name: "IX_Emploees_CarrierId",
                table: "Emploees");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Emploees");
        }
    }
}
