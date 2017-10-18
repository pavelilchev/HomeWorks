namespace SocialNetwork.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using SocialNetwork.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class SocialNetworkContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SocialNetworkDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<UserFriend>()
                .HasKey(uf => new { uf.UserFirstId, uf.UserSecondId });

            mb.Entity<User>()
                .HasMany(u => u.FriendsFirst)
                .WithOne(f => f.UserFirst)
                .HasForeignKey(f => f.UserFirstId)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<User>()
              .HasMany(u => u.FriendsSecond)
              .WithOne(f => f.UserSecond)
              .HasForeignKey(f => f.UserSecondId)
              .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<PictureAlbum>()
                .HasKey(pa => new { pa.PictureId, pa.AlbumId });

            mb.Entity<Picture>()
                .HasMany(p => p.Albums)
                .WithOne(a => a.Picture)
                .HasForeignKey(a => a.PictureId)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Album>()
                .HasMany(a => a.Pictures)
                .WithOne(p => p.Album)
                .HasForeignKey(a => a.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Album>()
                .HasOne(a => a.Owner)
                .WithMany(u => u.Albums)
                .HasForeignKey(a => a.OwnerId);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();
            var items = new Dictionary<object, object>();

            foreach (var entry in this.ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;
                var context = new ValidationContext(entity, serviceProvider, items);
                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
