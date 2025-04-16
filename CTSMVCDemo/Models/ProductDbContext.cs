using Microsoft.EntityFrameworkCore;

namespace CTSMVCDemo.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
      public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7C6F9K9\\SQLEXPRESS;database=ctsef;integrated security=true;trustservercertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.proId);

            modelBuilder.Entity<Product>()
               .HasOne(x => x.category)
               .WithMany(p => p.Products)
               .HasForeignKey(x => x.categoryId);

            modelBuilder.Entity<Category>()
                .HasKey(x => x.catId);

            modelBuilder.Entity<Product>()
                .HasData(new Product() { proId = 11, proName = "Laptop", price = 90000 },
                new Product() { proId = 12, proName = "Mac", price = 100000 });

            modelBuilder.Entity<Category>()
                .HasData(new Category { catId = 111, catName = "Electronics" },
                new Category { catId = 112, catName = "HomeAppliances" });
              
        }
    }
}
