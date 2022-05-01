using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "approaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    implementationDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maintanianceDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    concernId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approaches_concerns_concernId",
                        column: x => x.concernId,
                        principalTable: "concerns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_approaches_concernId",
                table: "approaches",
                column: "concernId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approaches");
        }
    }
}
