using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsApi.Migrations
{
    public partial class AddedStudentTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_StudentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentId",
                table: "Students");
        }
    }
}
