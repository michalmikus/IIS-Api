using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class removefkemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Connections_CarrierId",
                table: "Emploees");

            migrationBuilder.DropIndex(
                name: "IX_Emploees_CarrierId",
                table: "Emploees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Emploees_CarrierId",
                table: "Emploees",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Connections_CarrierId",
                table: "Emploees",
                column: "CarrierId",
                principalTable: "Connections",
                principalColumn: "Id");
        }
    }
}
