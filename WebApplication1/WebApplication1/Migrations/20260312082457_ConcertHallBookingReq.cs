using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ConcertHallBookingReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallBookings_Concerts_ConcertId",
                table: "HallBookings");

            migrationBuilder.AlterColumn<int>(
                name: "ConcertId",
                table: "HallBookings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HallBookings_Concerts_ConcertId",
                table: "HallBookings",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "ConcertId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallBookings_Concerts_ConcertId",
                table: "HallBookings");

            migrationBuilder.AlterColumn<int>(
                name: "ConcertId",
                table: "HallBookings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_HallBookings_Concerts_ConcertId",
                table: "HallBookings",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "ConcertId");
        }
    }
}
