namespace BankSystem.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BankSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "BankSystem.Data.BankSystemContext";
        }

        protected override void Seed(Data.BankSystemContext context)
        {
            var user = new User()
            {
                Username = "User",
                Password = "123",
                Email = "user@gmail.com"
            };
            context.Users.AddOrUpdate(u => u.Username, user);
            context.SaveChanges();

            var savingAccount = new SavingAccount()
            {
                 AccountNumber = "ABC",
                 Balance = 69m,
                 InterestRate = 0.5m,
                 UserId = user.Id
            };

            var checkingAccount = new CheckingAccount()
            {
                AccountNumber = "ABC",
                Balance = 69m,
                Fee = 1m,
                UserId = user.Id
            };

            context.SavingAccounts.AddOrUpdate(a => a.AccountNumber, savingAccount);
            context.CheckingAccounts.AddOrUpdate(a=>a.AccountNumber,checkingAccount);
            context.SaveChanges();
        }
    }
}
