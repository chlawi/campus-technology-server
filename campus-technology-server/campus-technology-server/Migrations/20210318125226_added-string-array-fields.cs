using Microsoft.EntityFrameworkCore.Migrations;

namespace campus_technology_server.Migrations
{
    public partial class addedstringarrayfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationNames",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetTags",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationNames",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "AssetTags",
                table: "AppleAppRequests");
        }
    }
}
