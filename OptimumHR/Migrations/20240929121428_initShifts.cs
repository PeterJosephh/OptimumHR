using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptimumHR.Migrations
{
    /// <inheritdoc />
    public partial class initShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_RequestStatus_StatusId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionReq_Employees_EmployeeId",
                table: "PermissionReq");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionReq_RequestStatus_StatusId",
                table: "PermissionReq");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationBalance_Employees_EmployeeId",
                table: "VacationBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationBalance_VacRule_VacRuleId",
                table: "VacationBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacRule",
                table: "VacRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacationBalance",
                table: "VacationBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionReq",
                table: "PermissionReq");

            migrationBuilder.RenameTable(
                name: "VacRule",
                newName: "VacRules");

            migrationBuilder.RenameTable(
                name: "VacationBalance",
                newName: "VacationBalances");

            migrationBuilder.RenameTable(
                name: "RequestStatus",
                newName: "RequestStatuses");

            migrationBuilder.RenameTable(
                name: "PermissionReq",
                newName: "PermissionReqs");

            migrationBuilder.RenameIndex(
                name: "IX_VacationBalance_VacRuleId",
                table: "VacationBalances",
                newName: "IX_VacationBalances_VacRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_VacationBalance_EmployeeId",
                table: "VacationBalances",
                newName: "IX_VacationBalances_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionReq_StatusId",
                table: "PermissionReqs",
                newName: "IX_PermissionReqs_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionReq_EmployeeId",
                table: "PermissionReqs",
                newName: "IX_PermissionReqs_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacRules",
                table: "VacRules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacationBalances",
                table: "VacationBalances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionReqs",
                table: "PermissionReqs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShiftRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftRuleId = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_ShiftRules_ShiftRuleId",
                        column: x => x.ShiftRuleId,
                        principalTable: "ShiftRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyDayOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftRuleId = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyDayOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyDayOffs_ShiftRules_ShiftRuleId",
                        column: x => x.ShiftRuleId,
                        principalTable: "ShiftRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftId",
                table: "Employees",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftRuleId",
                table: "Shift",
                column: "ShiftRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyDayOffs_ShiftRuleId",
                table: "WeeklyDayOffs",
                column: "ShiftRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Shift_ShiftId",
                table: "Employees",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_RequestStatuses_StatusId",
                table: "LeaveRequests",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionReqs_Employees_EmployeeId",
                table: "PermissionReqs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionReqs_RequestStatuses_StatusId",
                table: "PermissionReqs",
                column: "StatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationBalances_Employees_EmployeeId",
                table: "VacationBalances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationBalances_VacRules_VacRuleId",
                table: "VacationBalances",
                column: "VacRuleId",
                principalTable: "VacRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Shift_ShiftId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_RequestStatuses_StatusId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionReqs_Employees_EmployeeId",
                table: "PermissionReqs");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionReqs_RequestStatuses_StatusId",
                table: "PermissionReqs");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationBalances_Employees_EmployeeId",
                table: "VacationBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationBalances_VacRules_VacRuleId",
                table: "VacationBalances");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "WeeklyDayOffs");

            migrationBuilder.DropTable(
                name: "ShiftRules");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ShiftId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacRules",
                table: "VacRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacationBalances",
                table: "VacationBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionReqs",
                table: "PermissionReqs");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "VacRules",
                newName: "VacRule");

            migrationBuilder.RenameTable(
                name: "VacationBalances",
                newName: "VacationBalance");

            migrationBuilder.RenameTable(
                name: "RequestStatuses",
                newName: "RequestStatus");

            migrationBuilder.RenameTable(
                name: "PermissionReqs",
                newName: "PermissionReq");

            migrationBuilder.RenameIndex(
                name: "IX_VacationBalances_VacRuleId",
                table: "VacationBalance",
                newName: "IX_VacationBalance_VacRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_VacationBalances_EmployeeId",
                table: "VacationBalance",
                newName: "IX_VacationBalance_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionReqs_StatusId",
                table: "PermissionReq",
                newName: "IX_PermissionReq_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionReqs_EmployeeId",
                table: "PermissionReq",
                newName: "IX_PermissionReq_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacRule",
                table: "VacRule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacationBalance",
                table: "VacationBalance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionReq",
                table: "PermissionReq",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_RequestStatus_StatusId",
                table: "LeaveRequests",
                column: "StatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionReq_Employees_EmployeeId",
                table: "PermissionReq",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionReq_RequestStatus_StatusId",
                table: "PermissionReq",
                column: "StatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationBalance_Employees_EmployeeId",
                table: "VacationBalance",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationBalance_VacRule_VacRuleId",
                table: "VacationBalance",
                column: "VacRuleId",
                principalTable: "VacRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
