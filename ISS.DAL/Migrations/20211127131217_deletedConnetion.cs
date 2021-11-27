using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class deletedConnetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Connections_ConnectionId",
                table: "Emploees");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<Guid>");

            migrationBuilder.DropIndex(
                name: "IX_Emploees_ConnectionId",
                table: "Emploees");

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Emploees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConnectionId",
                table: "Emploees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<Guid>",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<Guid>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_ConnectionId",
                table: "Emploees",
                column: "ConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Connections_ConnectionId",
                table: "Emploees",
                column: "ConnectionId",
                principalTable: "Connections",
                principalColumn: "Id");
        }
    }
}
