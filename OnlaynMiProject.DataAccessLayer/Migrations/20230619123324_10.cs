using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlaynMiProject.DataAccessLayer.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendance_AspNetUsers_AppUserId",
                table: "EventAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendance_Event_EventId",
                table: "EventAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAttendance",
                table: "EventAttendance");

            migrationBuilder.RenameTable(
                name: "EventAttendance",
                newName: "EventAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendance_EventId",
                table: "EventAttendances",
                newName: "IX_EventAttendances_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendance_AppUserId",
                table: "EventAttendances",
                newName: "IX_EventAttendances_AppUserId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedTime",
                table: "Event",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAttendances",
                table: "EventAttendances",
                column: "EventAttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendances_AspNetUsers_AppUserId",
                table: "EventAttendances",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendances_Event_EventId",
                table: "EventAttendances",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendances_AspNetUsers_AppUserId",
                table: "EventAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendances_Event_EventId",
                table: "EventAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAttendances",
                table: "EventAttendances");

            migrationBuilder.RenameTable(
                name: "EventAttendances",
                newName: "EventAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendances_EventId",
                table: "EventAttendance",
                newName: "IX_EventAttendance_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventAttendances_AppUserId",
                table: "EventAttendance",
                newName: "IX_EventAttendance_AppUserId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedTime",
                table: "Event",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAttendance",
                table: "EventAttendance",
                column: "EventAttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendance_AspNetUsers_AppUserId",
                table: "EventAttendance",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendance_Event_EventId",
                table: "EventAttendance",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
