using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class Editt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_Cityd",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Cityd",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Cityd",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CityId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cityd",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Cityd",
                table: "Companies",
                column: "Cityd");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_Cityd",
                table: "Companies",
                column: "Cityd",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
