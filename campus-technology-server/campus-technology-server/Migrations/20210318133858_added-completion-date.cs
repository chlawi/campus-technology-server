using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace campus_technology_server.Migrations
{
    public partial class addedcompletiondate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "AppleAppRequests",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "AppleAppRequests");
        }
    }
}
