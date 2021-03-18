using Microsoft.EntityFrameworkCore.Migrations;

namespace campus_technology_server.Migrations
{
    public partial class refactoredmodeldefinitionsandrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationIds",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "ApplicationNames",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "Approver",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "AssetTags",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "DeviceIds",
                table: "AppleAppRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "AppleAppApplications");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "AppleAppApplications");

            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "AppleAppApplications");

            migrationBuilder.RenameColumn(
                name: "Requester",
                table: "AppleAppRequests",
                newName: "RequesterId");

            migrationBuilder.RenameColumn(
                name: "Provider",
                table: "AppleAppRequests",
                newName: "ProviderId");

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "AppleAppRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppleAppRejectReasons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppleAppRequestedApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    AppleAppRequestId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppleAppRequestedApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppleAppRequestedApplications_AppleAppRequests_AppleAppRequestId",
                        column: x => x.AppleAppRequestId,
                        principalTable: "AppleAppRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppleAppRequestedDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppleAppRequestId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppleAppRequestedDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppleAppRequestedDevices_AppleAppRequests_AppleAppRequestId",
                        column: x => x.AppleAppRequestId,
                        principalTable: "AppleAppRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppleAppVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppleAppVendors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppleAppRequestedApplications_AppleAppRequestId",
                table: "AppleAppRequestedApplications",
                column: "AppleAppRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AppleAppRequestedDevices_AppleAppRequestId",
                table: "AppleAppRequestedDevices",
                column: "AppleAppRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppleAppRequestedApplications");

            migrationBuilder.DropTable(
                name: "AppleAppRequestedDevices");

            migrationBuilder.DropTable(
                name: "AppleAppVendors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppleAppRejectReasons");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "AppleAppRequests",
                newName: "Requester");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "AppleAppRequests",
                newName: "Provider");

            migrationBuilder.AlterColumn<int>(
                name: "ApproverId",
                table: "AppleAppRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationIds",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationNames",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Approver",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetTags",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceIds",
                table: "AppleAppRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "AppleAppApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "AppleAppApplications",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "AppleAppApplications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
