using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicrosWPSShopping.ProductApi.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "id", "Category_name", "Description", "Image_url", "Price", "Name" },
                values: new object[] { 2L, "poder", "Hadouken do kakaroto", "A imagem que choca", 10m, "Hadouken" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "id", "Category_name", "Description", "Image_url", "Price", "Name" },
                values: new object[] { 3L, "poder", "Hadouken do kakaroto", "A imagem que choca", 20m, "Hadouken2" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "id", "Category_name", "Description", "Image_url", "Price", "Name" },
                values: new object[] { 4L, "poder", "Hadouken do kakaroto", "A imagem que choca", 30m, "Hadouken4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "id",
                keyValue: 4L);
        }
    }
}
