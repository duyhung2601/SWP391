using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "From Mixi With Love", "Bánh gạo An Tự Nhiên N" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Den tu mixigaming", "Bánh gạo An Tự Nhiên" });
        }
    }
}
