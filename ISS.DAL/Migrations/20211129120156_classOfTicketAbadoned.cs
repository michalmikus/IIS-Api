using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class classOfTicketAbadoned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelClass",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ConnectionId",
                table: "TimeTables",
                column: "ConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTables_Connections_ConnectionId",
                table: "TimeTables",
                column: "ConnectionId",
                principalTable: "Connections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Connections_ConnectionId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_ConnectionId",
                table: "TimeTables");

            migrationBuilder.AddColumn<int>(
                name: "TravelClass",
                table: "Tickets",
                type: "int",
                nullable: true);
        }
    }
}
