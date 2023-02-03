using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class V110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalDegree",
                table: "Exam",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalDegree",
                table: "Exam");
        }
    }
}
