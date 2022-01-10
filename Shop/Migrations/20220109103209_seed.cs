using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1L, "لوازم تحریر " },
                    { 2L, "لوازم برقی خانگی" },
                    { 3L, "خواروبار" },
                    { 4L, "موادپروتیینی" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandName", "CategoryId", "Description", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1L, "یونیبال", 1L, "---------", 50000m, "روان نویس" },
                    { 2L, "پنتر", 1L, "-----", 10000m, "خودکار" },
                    { 3L, "زبرا", 1L, "-----", 20000m, "خودکار" },
                    { 4L, "سامسونگ", 2L, "-----", 3000000m, "جاروبرقی" },
                    { 5L, "ال جی", 2L, "-----", 9000000m, "یخچال" },
                    { 6L, "بوش", 2L, "-----", 8000000m, "جاروبرقی" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
