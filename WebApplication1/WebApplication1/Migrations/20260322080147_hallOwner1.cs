using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class hallOwner1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Halls_hallOwnerId",
                table: "Halls");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_hallOwnerId",
                table: "Halls",
                column: "hallOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Halls_hallOwnerId",
                table: "Halls");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_hallOwnerId",
                table: "Halls",
                column: "hallOwnerId",
                unique: true);
        }
    }
}
