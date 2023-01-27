using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class Adding_StudentSubject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectDuration",
                table: "StudentsSubjects");

            migrationBuilder.AddColumn<double>(
                name: "SubjectDuration",
                table: "Subjects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectDuration",
                table: "Subjects");

            migrationBuilder.AddColumn<double>(
                name: "SubjectDuration",
                table: "StudentsSubjects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
