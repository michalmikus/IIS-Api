using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    public partial class nullableGuids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Emploees_ConfirmingEmploeeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassangerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stops_BoardingStopId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stops_DestinationStopId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "SeatEntity");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BoardingStopId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ConfirmingEmploeeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_DestinationStopId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PassangerId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassangerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "SeatCount",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatCount",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassangerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BoardingStopId",
                table: "Tickets",
                column: "BoardingStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConfirmingEmploeeId",
                table: "Tickets",
                column: "ConfirmingEmploeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DestinationStopId",
                table: "Tickets",
                column: "DestinationStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassangerId",
                table: "Tickets",
                column: "PassangerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatEntity_TicketEntityId",
                table: "SeatEntity",
                column: "TicketEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Emploees_ConfirmingEmploeeId",
                table: "Tickets",
                column: "ConfirmingEmploeeId",
                principalTable: "Emploees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassangerId",
                table: "Tickets",
                column: "PassangerId",
                principalTable: "Passengers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stops_BoardingStopId",
                table: "Tickets",
                column: "BoardingStopId",
                principalTable: "Stops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stops_DestinationStopId",
                table: "Tickets",
                column: "DestinationStopId",
                principalTable: "Stops",
                principalColumn: "Id");
        }
    }
}
