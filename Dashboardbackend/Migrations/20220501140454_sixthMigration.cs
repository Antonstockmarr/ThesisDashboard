using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_approaches_concerns_concernForeignKey",
                table: "approaches");

            migrationBuilder.DropIndex(
                name: "IX_approaches_concernForeignKey",
                table: "approaches");

            migrationBuilder.RenameColumn(
                name: "maintanianceDifficulty",
                table: "approaches",
                newName: "maintenanceDifficulty");

            migrationBuilder.AlterColumn<int>(
                name: "concernForeignKey",
                table: "approaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "maintenanceDifficulty",
                table: "approaches",
                newName: "maintanianceDifficulty");

            migrationBuilder.AlterColumn<int>(
                name: "concernForeignKey",
                table: "approaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_approaches_concernForeignKey",
                table: "approaches",
                column: "concernForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_approaches_concerns_concernForeignKey",
                table: "approaches",
                column: "concernForeignKey",
                principalTable: "concerns",
                principalColumn: "Id");
        }
    }
}
