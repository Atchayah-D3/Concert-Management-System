using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallBookings_Halls_HallBookingId",
                table: "HallBookings");

            migrationBuilder.AlterColumn<int>(
                name: "HallBookingId",
                table: "HallBookings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_HallBookings_HallId",
                table: "HallBookings",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_HallBookings_Halls_HallId",
                table: "HallBookings",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallBookings_Halls_HallId",
                table: "HallBookings");

            migrationBuilder.DropIndex(
                name: "IX_HallBookings_HallId",
                table: "HallBookings");

            migrationBuilder.AlterColumn<int>(
                name: "HallBookingId",
                table: "HallBookings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_HallBookings_Halls_HallBookingId",
                table: "HallBookings",
                column: "HallBookingId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
