using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDeptMemoCRUD.Migrations
{
    public partial class addedcoursehourscolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabHours",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LectureHours",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabHours",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LectureHours",
                table: "Course");
        }
    }
}
