using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopOnline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSliderDatatoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "sl1", "\\images\\slider\\3465d5e5-3259-4ba1-bed4-dab527431481.png", "sl1" },
                    { 2, "sl2", "\\images\\slider\\b63cb4d0-bbba-41db-93e4-ff6c5d7d65e9.png", "sl2" },
                    { 3, "sl3", "\\images\\slider\\c0fd6f84-67f7-4b84-8398-4a98d20968ae.jpg", "sl3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
