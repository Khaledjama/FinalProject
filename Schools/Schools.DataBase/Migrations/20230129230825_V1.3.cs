using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacherabsence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherSSN = table.Column<long>(type: "bigint", nullable: false),
                    TeacherSSN1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacherabsence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacherabsence_Teachers_TeacherSSN1",
                        column: x => x.TeacherSSN1,
                        principalTable: "Teachers",
                        principalColumn: "TeacherSSN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacherabsence_TeacherSSN1",
                table: "Teacherabsence",
                column: "TeacherSSN1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacherabsence");
        }
    }
}
