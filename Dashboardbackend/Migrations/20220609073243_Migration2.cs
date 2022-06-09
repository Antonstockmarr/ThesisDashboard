using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardbackend.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SetupURL",
                table: "setupConfigurations",
                newName: "SetupFiles");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "setupConfigurations",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SetupFiles",
                table: "setupConfigurations",
                newName: "SetupURL");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "setupConfigurations",
                newName: "ImageURL");
        }
    }
}
