namespace _4.ProductsMigration.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ProductsAddColumnDescription : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Products", "Description", c => c.String(nullable:false,defaultValue: "No description"));
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Products", "Description");
        }
    }
}
