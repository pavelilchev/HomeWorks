namespace _5.SalesMigration
{
    using System.Data.Entity;
    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
    }
}