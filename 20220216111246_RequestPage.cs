using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kanusaoft1.Migrations
{
    public partial class RequestPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TankItems_supplements_supplementname",
                table: "TankItems");

            migrationBuilder.RenameColumn(
                name: "supplementname",
                table: "TankItems",
                newName: "SupplementName");

            migrationBuilder.RenameIndex(
                name: "IX_TankItems_supplementname",
                table: "TankItems",
                newName: "IX_TankItems_SupplementName");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TankItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "locationaddress",
                table: "TankItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplementName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    SupplementAmount = table.Column<int>(nullable: false),
                    RequestPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetails",
                columns: table => new
                {
                    RequestDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    Supplement = table.Column<string>(nullable: true),
                    supplementname = table.Column<string>(nullable: true),
                    locationaddress = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDetails", x => x.RequestDetailId);
                    table.ForeignKey(
                        name: "FK_RequestDetails_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDetails_locations_locationaddress",
                        column: x => x.locationaddress,
                        principalTable: "locations",
                        principalColumn: "address",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestDetails_supplements_supplementname",
                        column: x => x.supplementname,
                        principalTable: "supplements",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TankItems_locationaddress",
                table: "TankItems",
                column: "locationaddress");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_RequestId",
                table: "RequestDetails",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_locationaddress",
                table: "RequestDetails",
                column: "locationaddress");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_supplementname",
                table: "RequestDetails",
                column: "supplementname");

            migrationBuilder.AddForeignKey(
                name: "FK_TankItems_supplements_SupplementName",
                table: "TankItems",
                column: "SupplementName",
                principalTable: "supplements",
                principalColumn: "name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TankItems_locations_locationaddress",
                table: "TankItems",
                column: "locationaddress",
                principalTable: "locations",
                principalColumn: "address",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TankItems_supplements_SupplementName",
                table: "TankItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TankItems_locations_locationaddress",
                table: "TankItems");

            migrationBuilder.DropTable(
                name: "RequestDetails");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_TankItems_locationaddress",
                table: "TankItems");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TankItems");

            migrationBuilder.DropColumn(
                name: "locationaddress",
                table: "TankItems");

            migrationBuilder.RenameColumn(
                name: "SupplementName",
                table: "TankItems",
                newName: "supplementname");

            migrationBuilder.RenameIndex(
                name: "IX_TankItems_SupplementName",
                table: "TankItems",
                newName: "IX_TankItems_supplementname");

            migrationBuilder.AddForeignKey(
                name: "FK_TankItems_supplements_supplementname",
                table: "TankItems",
                column: "supplementname",
                principalTable: "supplements",
                principalColumn: "name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
