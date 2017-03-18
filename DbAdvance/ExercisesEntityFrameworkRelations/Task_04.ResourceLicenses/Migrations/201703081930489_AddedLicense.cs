namespace Task_04.ResourceLicenses.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedLicense : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.Resource_Id)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Licenses", "Resource_Id", "dbo.Resources");
            this.DropIndex("dbo.Licenses", new[] { "Resource_Id" });
            this.DropTable("dbo.Licenses");
        }
    }
}
