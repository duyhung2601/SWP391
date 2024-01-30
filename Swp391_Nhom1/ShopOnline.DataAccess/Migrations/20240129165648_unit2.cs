using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class unit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bánh gạo An Tự Nhiênnn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bánh gạo An Tự Nhiên");
        }
    }
}
