using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptimumHR.Migrations
{
    /// <inheritdoc />
    public partial class AddedByDayOffRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "DayOffRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "DayOffRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "DayOffRequests");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "DayOffRequests");
        }
    }
}
