using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlaynMiProject.DataAccessLayer.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Groups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Groups",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Groups");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Day",
                table: "Groups",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "Groups",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
