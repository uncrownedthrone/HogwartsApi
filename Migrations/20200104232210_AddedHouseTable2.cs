using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsApi.Migrations
{
    public partial class AddedHouseTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_HouseId",
                table: "Students",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Houses_HouseId",
                table: "Students",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Houses_HouseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_HouseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Students");
        }
    }
}
