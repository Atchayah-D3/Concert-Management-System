using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ConcertHallBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Halls_HallId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_HallId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "ConcertSpecs");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Concerts");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "HallBookings",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "HallBookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HallBookings_ConcertId",
                table: "HallBookings",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_HallBookings_Concerts_ConcertId",
                table: "HallBookings",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "ConcertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallBookings_Concerts_ConcertId",
                table: "HallBookings");

            migrationBuilder.DropIndex(
                name: "IX_HallBookings_ConcertId",
                table: "HallBookings");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "HallBookings");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "HallBookings",
                newName: "status");

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "ConcertSpecs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Concerts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_HallId",
                table: "Concerts",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Halls_HallId",
                table: "Concerts",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId");
        }
    }
}
