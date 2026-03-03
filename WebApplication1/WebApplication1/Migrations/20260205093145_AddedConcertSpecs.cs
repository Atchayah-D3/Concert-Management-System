using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedConcertSpecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcertSpecs",
                columns: table => new
                {
                    ConcertSpecId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date_Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Artist = table.Column<string>(type: "text", nullable: false),
                    Venue = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ConcertId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertSpecs", x => x.ConcertSpecId);
                    table.ForeignKey(
                        name: "FK_ConcertSpecs_Concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concerts",
                        principalColumn: "ConcertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertSpecs_ConcertId",
                table: "ConcertSpecs",
                column: "ConcertId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertSpecs");
        }
    }
}
