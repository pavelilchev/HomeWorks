namespace BankSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.CheckingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.SavingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            this.DropTable("dbo.SavingAccounts");
            this.DropTable("dbo.CheckingAccounts");
        }
    }
}
