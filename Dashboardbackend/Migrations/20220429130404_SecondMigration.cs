using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboardbackend.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concerns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FocusAreaForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concerns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concerns_focusAreas_FocusAreaForeignKey",
                        column: x => x.FocusAreaForeignKey,
                        principalTable: "focusAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_concerns_FocusAreaForeignKey",
                table: "concerns",
                column: "FocusAreaForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concerns");
        }
    }
}
