namespace Shop.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("ShopContext")
        {
            Database.SetInitializer(new DropCreateSeed());
        }
        
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOptional(p => p.Buyer)
                .WithMany(u=>u.BoughtProducts)
                .HasForeignKey(e=>e.BuyerId);

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Seller)
                .WithMany(u=>u.SoldProducts)
                .HasForeignKey(p=>p.SeilerId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(t =>
                {
                    t.MapLeftKey("UserId");
                    t.MapRightKey("FriendId");
                    t.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}