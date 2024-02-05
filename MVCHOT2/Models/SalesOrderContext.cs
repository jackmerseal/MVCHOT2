using Microsoft.EntityFrameworkCore;
namespace MVCHOT2.Models
{
    public class SalesOrderContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set;}

        public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category() { CategoryID = 1, CategoryName = "Accessories" },
            new Category() { CategoryID = 2, CategoryName = "Bikes" },
            new Category() { CategoryID = 3, CategoryName = "Clothing" },
            new Category() { CategoryID = 4, CategoryName = "Components" },
            new Category() { CategoryID = 5, CategoryName = "Car racks" },
            new Category() { CategoryID = 6, CategoryName = "Wheels" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductID = 1, ProductName = "AeroFlo ATB Wheels", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 189.00M, ProductQty = 40, CategoryId = 4 },
                new Product() { ProductID = 2, ProductName = "Clear Shade 85-T Glasses", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 45.00M, ProductQty = 14, CategoryId = 1 },
                new Product() { ProductID = 3, ProductName = "Cosmic Elite Road Warrior Wheels", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 165.00M, ProductQty = 22, CategoryId = 4 },
                new Product() { ProductID = 4, ProductName = "Cycle-Doc Pro Repair Stan", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 166.00M, ProductQty = 12, CategoryId = 1 },
                new Product() { ProductID = 5, ProductName = "Dog Ear Aero-Flow Floor Pump", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 5.00M, ProductQty = 25, CategoryId = 1 }
            );
        }
    }
}
