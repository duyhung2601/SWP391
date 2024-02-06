using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopOnline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Company", "Description", "ImageUrl", "ListPrice", "Name", "Price", "Price100", "Price50", "SKU" },
                values: new object[,]
                {
                    { 3, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 4, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 5, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 6, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 7, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 8, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 9, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 10, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 11, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 12, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 13, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 14, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 15, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 16, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 17, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 18, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" },
                    { 19, 1, "MixiGaming", "Den tu mixigaming", "", 99.0, "Bánh gạo An Tự Nhiên", 90.0, 80.0, 85.0, "220909100" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
