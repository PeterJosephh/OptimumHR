using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptimumHR.Migrations
{
    /// <inheritdoc />
    public partial class EditDayOffRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "DayOffRequests",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "DayOffRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "DayOffRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DayOffRequests");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "DayOffRequests");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DayOffRequests",
                newName: "Date");
        }
    }
}
