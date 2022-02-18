using Microsoft.EntityFrameworkCore.Migrations;

namespace kanusaoft1.Migrations
{
    public partial class TankItemAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TankItems",
                columns: table => new
                {
                    TankItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplementname = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    TankId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankItems", x => x.TankItemId);
                    table.ForeignKey(
                        name: "FK_TankItems_supplements_supplementname",
                        column: x => x.supplementname,
                        principalTable: "supplements",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TankItems_supplementname",
                table: "TankItems",
                column: "supplementname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TankItems");
        }
    }
}
