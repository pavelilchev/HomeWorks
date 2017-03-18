namespace Photo.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Task_7_Tags : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);

            this.CreateTable(
                "dbo.TagAlbums",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Album_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.TagAlbums", "Album_Id", "dbo.Albums");
            this.DropForeignKey("dbo.TagAlbums", "Tag_Id", "dbo.Tags");
            this.DropIndex("dbo.TagAlbums", new[] { "Album_Id" });
            this.DropIndex("dbo.TagAlbums", new[] { "Tag_Id" });
            this.DropIndex("dbo.Tags", new[] { "Name" });
            this.DropTable("dbo.TagAlbums");
            this.DropTable("dbo.Tags");
        }
    }
}
