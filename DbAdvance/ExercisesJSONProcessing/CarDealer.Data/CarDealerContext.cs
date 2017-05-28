namespace CarDealer.Data
{
    using System.Data.Entity;
    using Models;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("CarDealerContext")
        {
            Database.SetInitializer(new CreateIfNotExistSeed());
        }

         public virtual DbSet<Car> Cars { get; set; }
         public virtual DbSet<Sale> Sales { get; set; }
         public virtual DbSet<Customer> Customers { get; set; }
         public virtual DbSet<Part> Parts { get; set; }
         public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}