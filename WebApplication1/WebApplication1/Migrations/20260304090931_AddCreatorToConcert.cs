using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorToConcert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Concerts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_CreatorId",
                table: "Concerts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Users_CreatorId",
                table: "Concerts",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Users_CreatorId",
                table: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Concerts_CreatorId",
                table: "Concerts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Concerts");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
