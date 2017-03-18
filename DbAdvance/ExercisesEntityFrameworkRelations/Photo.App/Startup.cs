namespace Photo.App
{
    using System;
    using System.Data.Entity.Validation;
    using Data;
    using Models;
    using Utils;

    public class Startup
    {
        public static void Main()
        {
            PhotoContext ctx = new PhotoContext();
            ctx.Database.Initialize(true);

            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            var tag = new Tag()
            {
                Name = tagName
            };
            ctx.Tags.Add(tag);

            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                tag.Name = TagTransofrmer.Transform(tagName);
                ctx.SaveChanges();
            }


            ctx.PhotographerAlbumses.Add(new PhotographerAlbums()
            {
                Album = ctx.Albums.Find(1),
                Photographer = ctx.Photographers.Find(1),
                Role = Role.Owner
            });
            ctx.SaveChanges();
        }
    }
}
