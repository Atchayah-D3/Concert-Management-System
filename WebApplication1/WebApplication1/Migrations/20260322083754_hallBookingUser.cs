using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class hallBookingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Users_hallOwnerId",
                table: "Halls");

            migrationBuilder.AlterColumn<int>(
                name: "hallOwnerId",
                table: "Halls",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HallBookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HallBookings_UserId",
                table: "HallBookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HallBookings_Users_UserId",
                table: "HallBookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Users_hallOwnerId",
                table: "Halls",
                column: "hallOwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallBookings_Users_UserId",
                table: "HallBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Users_hallOwnerId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_HallBookings_UserId",
                table: "HallBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HallBookings");

            migrationBuilder.AlterColumn<int>(
                name: "hallOwnerId",
                table: "Halls",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Users_hallOwnerId",
                table: "Halls",
                column: "hallOwnerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
