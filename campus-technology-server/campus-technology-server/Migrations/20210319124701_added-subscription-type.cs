using Microsoft.EntityFrameworkCore.Migrations;

namespace campus_technology_server.Migrations
{
    public partial class addedsubscriptiontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionType",
                table: "AppleAppRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "AppleAppRequests");
        }
    }
}
