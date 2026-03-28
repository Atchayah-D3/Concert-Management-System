using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ConcertHall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomHall",
                table: "Concerts",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Halls_HallId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_HallId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "CustomHall",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Concerts");
        }
    }
}
