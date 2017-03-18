namespace _1.LocalStore
{
    using System.Data.Entity;
    using Models;

    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
        }

         public virtual DbSet<Product> Products { get; set; }
    }
}