using Microsoft.EntityFrameworkCore.Migrations;

namespace campus_technology_server.Migrations
{
    public partial class addrelateddatafields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationIds",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "AppleAppRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIds",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RejectReasonId",
                table: "AppleAppRequests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationIds",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "DeviceIds",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "RejectReasonId",
                table: "AppleAppRequests");
        }
    }
}
