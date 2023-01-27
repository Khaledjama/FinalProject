using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class Add_R_S_P4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parents",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "parents");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Students",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentSSN",
                table: "parents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_parents",
                table: "parents",
                column: "ParentSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "parents",
                principalColumn: "ParentSSN",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parents",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "ParentSSN",
                table: "parents");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "parents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parents",
                table: "parents",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "parents",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
