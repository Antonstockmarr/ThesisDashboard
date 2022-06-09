using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class Migration1 : Migration
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
                name: "setupConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetupURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setupConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tools", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "approachTools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproachId = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationDifficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approachTools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approachTools_approaches_ApproachId",
                        column: x => x.ApproachId,
                        principalTable: "approaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_approachTools_tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "configurationPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproachToolId = table.Column<int>(type: "int", nullable: false),
                    SetupConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurationPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_configurationPackages_approachTools_ApproachToolId",
                        column: x => x.ApproachToolId,
                        principalTable: "approachTools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_configurationPackages_setupConfigurations_SetupConfigurationId",
                        column: x => x.SetupConfigurationId,
                        principalTable: "setupConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approaches_ConcernId",
                table: "approaches",
                column: "ConcernId");

            migrationBuilder.CreateIndex(
                name: "IX_approachTools_ApproachId",
                table: "approachTools",
                column: "ApproachId");

            migrationBuilder.CreateIndex(
                name: "IX_approachTools_ToolId",
                table: "approachTools",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_concerns_ObjectiveId",
                table: "concerns",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_configurationPackages_ApproachToolId",
                table: "configurationPackages",
                column: "ApproachToolId");

            migrationBuilder.CreateIndex(
                name: "IX_configurationPackages_SetupConfigurationId",
                table: "configurationPackages",
                column: "SetupConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configurationPackages");

            migrationBuilder.DropTable(
                name: "approachTools");

            migrationBuilder.DropTable(
                name: "setupConfigurations");

            migrationBuilder.DropTable(
                name: "approaches");

            migrationBuilder.DropTable(
                name: "tools");

            migrationBuilder.DropTable(
                name: "concerns");

            migrationBuilder.DropTable(
                name: "objectives");
        }
    }
}
