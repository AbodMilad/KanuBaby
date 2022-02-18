using Microsoft.EntityFrameworkCore.Migrations;

namespace kanusaoft1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    address = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.address);
                });

            migrationBuilder.CreateTable(
                name: "supplements",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    locationaddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplements", x => x.name);
                    table.ForeignKey(
                        name: "FK_supplements_locations_locationaddress",
                        column: x => x.locationaddress,
                        principalTable: "locations",
                        principalColumn: "address",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supplements_locationaddress",
                table: "supplements",
                column: "locationaddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supplements");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
