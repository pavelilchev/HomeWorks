namespace BankSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CheckingAccounts", newName: "Accounts");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "InterestRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Accounts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Accounts", "Fee", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.Accounts", "UserId");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropTable("dbo.SavingAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SavingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserId" });
            AlterColumn("dbo.Accounts", "Fee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Accounts", "Discriminator");
            DropColumn("dbo.Accounts", "InterestRate");
            DropColumn("dbo.Accounts", "UserId");
            DropTable("dbo.Users");
            RenameTable(name: "dbo.Accounts", newName: "CheckingAccounts");
        }
    }
}
