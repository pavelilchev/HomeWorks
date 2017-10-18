namespace MyCoolWebServer.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.Models;

    public class CakesContext : DbContext
    {
        public DbSet<Cake> Cakes { get; set; }

        public DbSet<ShoppingCart> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.;Database=CakesDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<CakeShoppingCart>()
                .HasKey(cc => new { cc.CakeId, cc.ShopingCartId });

            mb.Entity<Cake>()
                .HasMany(c => c.Carts)
                .WithOne(c => c.Cake)
                .HasForeignKey(c => c.CakeId);

            mb.Entity<ShoppingCart>()
              .HasMany(c => c.Orders)
              .WithOne(c => c.ShoppingCart)
              .HasForeignKey(c => c.ShopingCartId);
        }
    }
}
