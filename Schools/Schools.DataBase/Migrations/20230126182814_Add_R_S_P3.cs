using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class Add_R_S_P3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "parents",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "parents",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
