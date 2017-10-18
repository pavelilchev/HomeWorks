namespace ShopHierarchy.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Salesman> Salesmans { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ShopDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Salesman>()
                .HasMany(s => s.Customers)
                .WithOne(c => c.Salesman)
                .HasForeignKey(c => c.SalesmanId);

            mb.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            mb.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId);

            mb.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ItemId });

            mb.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            mb.Entity<Item>()
                .HasMany(i => i.Orders)
                .WithOne(oi => oi.Item)
                .HasForeignKey(oi => oi.ItemId);

            mb.Entity<Review>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Reviews)
                .HasForeignKey(r => r.ItemId);
        }
    }
}
