using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertSpecs_Concerts_ConcertId",
                table: "ConcertSpecs");

            migrationBuilder.DropIndex(
                name: "IX_ConcertSpecs_ConcertId",
                table: "ConcertSpecs");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "ConcertSpecs");

            migrationBuilder.AddColumn<int>(
                name: "ConcertSpecId",
                table: "Concerts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ConcertSpecId",
                table: "Concerts",
                column: "ConcertSpecId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_ConcertSpecs_ConcertSpecId",
                table: "Concerts",
                column: "ConcertSpecId",
                principalTable: "ConcertSpecs",
                principalColumn: "ConcertSpecId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_ConcertSpecs_ConcertSpecId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_ConcertSpecId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "ConcertSpecId",
                table: "Concerts");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "ConcertSpecs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConcertSpecs_ConcertId",
                table: "ConcertSpecs",
                column: "ConcertId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertSpecs_Concerts_ConcertId",
                table: "ConcertSpecs",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "ConcertId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
