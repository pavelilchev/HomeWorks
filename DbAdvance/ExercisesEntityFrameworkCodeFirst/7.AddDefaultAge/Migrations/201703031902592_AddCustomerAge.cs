namespace _7.AddDefaultAge.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAge : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false,defaultValue:20));
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Customers", "Age");
        }
    }
}
