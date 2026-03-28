using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class hallOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hallOwnerId",
                table: "Halls",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Halls_hallOwnerId",
                table: "Halls",
                column: "hallOwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Users_hallOwnerId",
                table: "Halls",
                column: "hallOwnerId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Users_hallOwnerId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_hallOwnerId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "hallOwnerId",
                table: "Halls");
        }
    }
}
