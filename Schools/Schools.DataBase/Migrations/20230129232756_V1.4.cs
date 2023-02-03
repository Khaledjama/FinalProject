using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacherabsence_Teachers_TeacherSSN1",
                table: "Teacherabsence");

            migrationBuilder.DropIndex(
                name: "IX_Teacherabsence_TeacherSSN1",
                table: "Teacherabsence");

            migrationBuilder.DropColumn(
                name: "TeacherSSN1",
                table: "Teacherabsence");

            migrationBuilder.CreateIndex(
                name: "IX_Teacherabsence_TeacherSSN",
                table: "Teacherabsence",
                column: "TeacherSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacherabsence_Teachers_TeacherSSN",
                table: "Teacherabsence",
                column: "TeacherSSN",
                principalTable: "Teachers",
                principalColumn: "TeacherSSN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacherabsence_Teachers_TeacherSSN",
                table: "Teacherabsence");

            migrationBuilder.DropIndex(
                name: "IX_Teacherabsence_TeacherSSN",
                table: "Teacherabsence");

            migrationBuilder.AddColumn<long>(
                name: "TeacherSSN1",
                table: "Teacherabsence",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacherabsence_TeacherSSN1",
                table: "Teacherabsence",
                column: "TeacherSSN1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacherabsence_Teachers_TeacherSSN1",
                table: "Teacherabsence",
                column: "TeacherSSN1",
                principalTable: "Teachers",
                principalColumn: "TeacherSSN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
