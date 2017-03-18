namespace Photo.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Task_6_Albums : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BackgroundColor = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        Photographer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .Index(t => t.Photographer_Id);

            this.CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Caption = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.PictureAlbums",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Album_Id })
                .ForeignKey("dbo.Pictures", t => t.Picture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Picture_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.PictureAlbums", "Album_Id", "dbo.Albums");
            this.DropForeignKey("dbo.PictureAlbums", "Picture_Id", "dbo.Pictures");
            this.DropForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers");
            this.DropIndex("dbo.PictureAlbums", new[] { "Album_Id" });
            this.DropIndex("dbo.PictureAlbums", new[] { "Picture_Id" });
            this.DropIndex("dbo.Albums", new[] { "Photographer_Id" });
            this.DropTable("dbo.PictureAlbums");
            this.DropTable("dbo.Pictures");
            this.DropTable("dbo.Albums");
        }
    }
}
