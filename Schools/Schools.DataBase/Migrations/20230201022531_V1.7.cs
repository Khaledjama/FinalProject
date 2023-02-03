using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class V17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Subjects_SubjectId",
                table: "ExamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult");

            migrationBuilder.DropIndex(
                name: "IX_ExamResult_StudentSSN",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExamResult");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "ExamResult",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ExamDegree",
                table: "ExamResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "ExamName",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult",
                columns: new[] { "StudentSSN", "SubjectId", "ExamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Subjects_SubjectId",
                table: "ExamResult",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResult_Subjects_SubjectId",
                table: "ExamResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult");

            migrationBuilder.DropColumn(
                name: "ExamDegree",
                table: "ExamResult");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "ExamResult",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExamResult",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ExamName",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamResult",
                table: "ExamResult",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResult_StudentSSN",
                table: "ExamResult",
                column: "StudentSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResult_Subjects_SubjectId",
                table: "ExamResult",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "CodeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
