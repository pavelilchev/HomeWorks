namespace Photo.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class PhotoContext : DbContext
    {
        public PhotoContext()
            : base("PhotoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoContext,Configuration>());
        }
       
        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<PhotographerAlbums> PhotographerAlbumses { get; set; }
    }
}