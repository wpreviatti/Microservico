using Microsoft.EntityFrameworkCore;

namespace MicrosWPSShopping.ProductApi.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                CategoryName = "poder",
                Description = "Hadouken do kakaroto",
                ImageUrl = "A imagem que choca",
                name = "Hadouken",
                Price = 10
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                CategoryName = "poder",
                Description = "Hadouken do kakaroto",
                ImageUrl = "A imagem que choca",
                name = "Hadouken2",
                Price = 20
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                CategoryName = "poder",
                Description = "Hadouken do kakaroto",
                ImageUrl = "A imagem que choca",
                name = "Hadouken4",
                Price = 30
            });
        }
    }
}
