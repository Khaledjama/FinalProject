using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.DataBase.Migrations
{
    public partial class Add_R_S_P2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "parents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parents_User_Id",
                table: "parents",
                column: "User_Id",
                unique: true,
                filter: "[User_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_parents_AspNetUsers_User_Id",
                table: "parents",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parents_AspNetUsers_User_Id",
                table: "parents");

            migrationBuilder.DropIndex(
                name: "IX_parents_User_Id",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "parents");
        }
    }
}
