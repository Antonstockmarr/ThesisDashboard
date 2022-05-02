using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concerns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concerns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concerns_objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementationDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcernId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approaches_concerns_ConcernId",
                        column: x => x.ConcernId,
                        principalTable: "concerns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approaches_ConcernId",
                table: "approaches",
                column: "ConcernId");

            migrationBuilder.CreateIndex(
                name: "IX_concerns_ObjectiveId",
                table: "concerns",
                column: "ObjectiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approaches");

            migrationBuilder.DropTable(
                name: "concerns");

            migrationBuilder.DropTable(
                name: "objectives");
        }
    }
}
