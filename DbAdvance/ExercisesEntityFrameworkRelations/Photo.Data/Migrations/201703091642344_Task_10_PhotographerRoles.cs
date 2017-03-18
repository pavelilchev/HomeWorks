namespace Photo.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Task_10_PhotographerRoles : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.PhotographerAlbums", "Photographer_Id", "dbo.Photographers");
            this.DropForeignKey("dbo.PhotographerAlbums", "Album_Id", "dbo.Albums");
            this.DropIndex("dbo.PhotographerAlbums", new[] { "Photographer_Id" });
            this.DropIndex("dbo.PhotographerAlbums", new[] { "Album_Id" });

            this.DropTable("dbo.PhotographerAlbums");

            this.CreateTable(
                "dbo.PhotographerAlbums",
                c => new
                    {
                        PhotographerId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PhotographerId, t.AlbumId })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Photographers", t => t.PhotographerId, cascadeDelete: true)
                .Index(t => t.PhotographerId)
                .Index(t => t.AlbumId);
        }
        
        public override void Down()
        {
            this.CreateTable(
                "dbo.PhotographerAlbums",
                c => new
                    {
                        Photographer_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photographer_Id, t.Album_Id });

            this.DropForeignKey("dbo.PhotographerAlbums", "PhotographerId", "dbo.Photographers");
            this.DropForeignKey("dbo.PhotographerAlbums", "AlbumId", "dbo.Albums");
            this.DropIndex("dbo.PhotographerAlbums", new[] { "AlbumId" });
            this.DropIndex("dbo.PhotographerAlbums", new[] { "PhotographerId" });
            this.DropTable("dbo.PhotographerAlbums");
            this.CreateIndex("dbo.PhotographerAlbums", "Album_Id");
            this.CreateIndex("dbo.PhotographerAlbums", "Photographer_Id");
            this.AddForeignKey("dbo.PhotographerAlbums", "Album_Id", "dbo.Albums", "Id", cascadeDelete: true);
            this.AddForeignKey("dbo.PhotographerAlbums", "Photographer_Id", "dbo.Photographers", "Id", cascadeDelete: true);
        }
    }
}
