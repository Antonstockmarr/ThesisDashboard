using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_approaches_concerns_concernId",
                table: "approaches");

            migrationBuilder.DropIndex(
                name: "IX_approaches_concernId",
                table: "approaches");

            migrationBuilder.DropColumn(
                name: "concernId",
                table: "approaches");

            migrationBuilder.CreateIndex(
                name: "IX_approaches_concernForeignKey",
                table: "approaches",
                column: "concernForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_approaches_concerns_concernForeignKey",
                table: "approaches",
                column: "concernForeignKey",
                principalTable: "concerns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_approaches_concerns_concernForeignKey",
                table: "approaches");

            migrationBuilder.DropIndex(
                name: "IX_approaches_concernForeignKey",
                table: "approaches");

            migrationBuilder.AddColumn<int>(
                name: "concernId",
                table: "approaches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_approaches_concernId",
                table: "approaches",
                column: "concernId");

            migrationBuilder.AddForeignKey(
                name: "FK_approaches_concerns_concernId",
                table: "approaches",
                column: "concernId",
                principalTable: "concerns",
                principalColumn: "Id");
        }
    }
}
