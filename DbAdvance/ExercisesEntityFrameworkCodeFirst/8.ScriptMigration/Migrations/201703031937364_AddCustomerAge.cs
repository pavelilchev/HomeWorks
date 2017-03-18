namespace _8.ScriptMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false,defaultValue:20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Age");
        }
    }
}
