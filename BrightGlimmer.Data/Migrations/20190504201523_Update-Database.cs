using Microsoft.EntityFrameworkCore.Migrations;

namespace BrightGlimmer.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "AssignedCourses",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "AssignedCourses",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
