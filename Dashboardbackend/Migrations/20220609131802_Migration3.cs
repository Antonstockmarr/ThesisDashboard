using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_configurationPackages_setupConfigurations_SetupConfigurationId",
                table: "configurationPackages");

            migrationBuilder.DropTable(
                name: "setupConfigurations");

            migrationBuilder.AlterColumn<int>(
                name: "SetupConfigurationId",
                table: "configurationPackages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationId",
                table: "configurationPackages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetupFiles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_configurationPackages_configurations_SetupConfigurationId",
                table: "configurationPackages",
                column: "SetupConfigurationId",
                principalTable: "configurations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_configurationPackages_configurations_SetupConfigurationId",
                table: "configurationPackages");

            migrationBuilder.DropTable(
                name: "configurations");

            migrationBuilder.DropColumn(
                name: "ConfigurationId",
                table: "configurationPackages");

            migrationBuilder.AlterColumn<int>(
                name: "SetupConfigurationId",
                table: "configurationPackages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "setupConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetupFiles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setupConfigurations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_configurationPackages_setupConfigurations_SetupConfigurationId",
                table: "configurationPackages",
                column: "SetupConfigurationId",
                principalTable: "setupConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
