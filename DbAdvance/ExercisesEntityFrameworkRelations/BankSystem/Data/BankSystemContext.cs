namespace BankSystem.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class BankSystemContext : DbContext
    {
        public BankSystemContext()
            : base("name=BankSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankSystemContext, Configuration>());
        }
        
         public virtual DbSet<CheckingAccount> CheckingAccounts { get; set; }

         public virtual DbSet<SavingAccount> SavingAccounts { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}