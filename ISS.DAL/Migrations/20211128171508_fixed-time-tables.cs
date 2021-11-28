using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class fixedtimetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTables_Connections_ConnectionId",
                table: "TimeTables");

            migrationBuilder.DropIndex(
                name: "IX_TimeTables_ConnectionId",
                table: "TimeTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
