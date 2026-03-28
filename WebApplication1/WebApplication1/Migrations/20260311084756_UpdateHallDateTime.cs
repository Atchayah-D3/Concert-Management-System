using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHallDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "HallBookings");

            migrationBuilder.RenameColumn(
                name: "TimeDate",
                table: "HallBookings",
                newName: "ToDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDateTime",
                table: "HallBookings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDateTime",
                table: "HallBookings");

            migrationBuilder.RenameColumn(
                name: "ToDateTime",
                table: "HallBookings",
                newName: "TimeDate");

            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "HallBookings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
