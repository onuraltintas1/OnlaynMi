using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlaynMiProject.DataAccessLayer.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Event");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Event",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
