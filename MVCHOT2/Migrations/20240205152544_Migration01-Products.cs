using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHOT2.Migrations
{
    public partial class Migration01Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductQty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Accessories" },
                    { 2, "Bikes" },
                    { 3, "Clothing" },
                    { 4, "Components" },
                    { 5, "Car racks" },
                    { 6, "Wheels" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryId", "ProductDescLong", "ProductDescShort", "ProductImage", "ProductName", "ProductPrice", "ProductQty" },
                values: new object[,]
                {
                    { 1, 4, "", "", "", "AeroFlo ATB Wheels", 189.00m, 40 },
                    { 2, 1, "", "", "", "Clear Shade 85-T Glasses", 45.00m, 14 },
                    { 3, 4, "", "", "", "Cosmic Elite Road Warrior Wheels", 165.00m, 22 },
                    { 4, 1, "", "", "", "Cycle-Doc Pro Repair Stan", 166.00m, 12 },
                    { 5, 1, "", "", "", "Dog Ear Aero-Flow Floor Pump", 5.00m, 25 }
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
