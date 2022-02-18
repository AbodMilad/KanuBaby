using Microsoft.EntityFrameworkCore.Migrations;

namespace kanusaoft1.Migrations
{
    public partial class NewDataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "address", "name" },
                values: new object[,]
                {
                    { "Wsta", "Mimar" },
                    { "4rbye", "Shamomar" },
                    { "al-whde str", "al-slam" }
                });

            migrationBuilder.InsertData(
                table: "supplements",
                columns: new[] { "name", "amount", "locationaddress" },
                values: new object[,]
                {
                    { "Water", 30, null },
                    { "Gazoline", 30, null },
                    { "Disel", 30, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "address",
                keyValue: "4rbye");

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "address",
                keyValue: "al-whde str");

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "address",
                keyValue: "Wsta");

            migrationBuilder.DeleteData(
                table: "supplements",
                keyColumn: "name",
                keyValue: "Disel");

            migrationBuilder.DeleteData(
                table: "supplements",
                keyColumn: "name",
                keyValue: "Gazoline");

            migrationBuilder.DeleteData(
                table: "supplements",
                keyColumn: "name",
                keyValue: "Water");
        }
    }
}
