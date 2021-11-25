using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class version32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Carriers_ConnectionId",
                table: "Emploees");

            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Connections_ConnectionEntityId",
                table: "Emploees");

            migrationBuilder.RenameColumn(
                name: "ConnectionEntityId",
                table: "Emploees",
                newName: "CarrierEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Emploees_ConnectionEntityId",
                table: "Emploees",
                newName: "IX_Emploees_CarrierEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Carriers_CarrierEntityId",
                table: "Emploees",
                column: "CarrierEntityId",
                principalTable: "Carriers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Connections_ConnectionId",
                table: "Emploees",
                column: "ConnectionId",
                principalTable: "Connections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Carriers_CarrierEntityId",
                table: "Emploees");

            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Connections_ConnectionId",
                table: "Emploees");

            migrationBuilder.RenameColumn(
                name: "CarrierEntityId",
                table: "Emploees",
                newName: "ConnectionEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Emploees_CarrierEntityId",
                table: "Emploees",
                newName: "IX_Emploees_ConnectionEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Carriers_ConnectionId",
                table: "Emploees",
                column: "ConnectionId",
                principalTable: "Carriers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Connections_ConnectionEntityId",
                table: "Emploees",
                column: "ConnectionEntityId",
                principalTable: "Connections",
                principalColumn: "Id");
        }
    }
}
