using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class V18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolYearId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchoolYearsId",
                table: "Exam",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SchoolYearsId",
                table: "Exam",
                column: "SchoolYearsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_SchoolYears_SchoolYearsId",
                table: "Exam",
                column: "SchoolYearsId",
                principalTable: "SchoolYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_SchoolYears_SchoolYearsId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_SchoolYearsId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "SchoolYearId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "SchoolYearsId",
                table: "Exam");
        }
    }
}
