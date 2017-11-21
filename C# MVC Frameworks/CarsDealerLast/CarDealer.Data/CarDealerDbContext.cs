namespace CarDealer.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;
    using CarDealer.Domain;

    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<PartCars>()
               .HasKey(pc => new { pc.PartId, pc.CarId });

            mb.Entity<Car>()
                .HasMany(c => c.Parts)
                .WithOne(p => p.Car)
                .HasForeignKey(p => p.CarId);

            mb.Entity<Car>()
               .HasMany(c => c.Sales)
               .WithOne(s => s.Car)
               .HasForeignKey(s => s.CarId);

            mb.Entity<Part>()
                .HasMany(p => p.Cars)
                .WithOne(c => c.Part)
                .HasForeignKey(c => c.PartId);

            mb.Entity<Part>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Parts)
                .HasForeignKey(p => p.SupplierId);

            mb.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);

            base.OnModelCreating(mb);
        }
    }
}
