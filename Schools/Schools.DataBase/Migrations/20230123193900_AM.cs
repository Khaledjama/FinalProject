using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_User_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdress_Student_StudentSSN",
                table: "StudentAdress");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Student_StudentId",
                table: "StudentsSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_User_Id",
                table: "Students",
                newName: "IX_Students_User_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudenntSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdress_Students_StudentSSN",
                table: "StudentAdress",
                column: "StudentSSN",
                principalTable: "Students",
                principalColumn: "StudenntSSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_User_Id",
                table: "Students",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Students_StudentId",
                table: "StudentsSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudenntSSN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAdress_Students_StudentSSN",
                table: "StudentAdress");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_User_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Students_StudentId",
                table: "StudentsSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_User_Id",
                table: "Student",
                newName: "IX_Student_User_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudenntSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_User_Id",
                table: "Student",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAdress_Student_StudentSSN",
                table: "StudentAdress",
                column: "StudentSSN",
                principalTable: "Student",
                principalColumn: "StudenntSSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Student_StudentId",
                table: "StudentsSubjects",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudenntSSN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
