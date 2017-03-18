namespace Photo.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "Photo.Data.PhotoContext";
        }

        protected override void Seed(PhotoContext context)
        {
            SeedPhotograpers(context);
            SeedAlbums(context);
            SeedPictures(context);
        }

        private static void SeedPhotograpers(PhotoContext context)
        {
            context.Photographers.AddOrUpdate(p=>p.Id,
                new Photographer()
                {
                    Id = 1,
                    Username = "Purviq",
                    Password = "dsfg346fdh5",
                    Email = "purviq@gmail.com",
                    RegisterDate = DateTime.Now,
                    BirthDate = DateTime.Now.AddYears(-20)
                },
                new Photographer()
                {
                    Id = 2,
                    Username = "Vtoriq",
                    Password = "rtyg346uh5",
                    Email = "Vtoriq@gmail.com",
                    RegisterDate = DateTime.Now,
                    BirthDate = DateTime.Now.AddYears(-30)
                },
                new Photographer()
                {
                    Id = 3,
                    Username = "Tretiq",
                    Password = "ertyh66fdh5",
                    Email = "Tretiq@gmail.com",
                    RegisterDate = DateTime.Now,
                    BirthDate = DateTime.Now.AddYears(-25)
                }
            );

            context.SaveChanges();
        }

        private static void SeedAlbums(PhotoContext context)
        {
            context.Albums.AddOrUpdate(p => p.Id,
                new Album()
                {
                    Id = 1,
                    Name = "Stari pesni",
                    BackgroundColor = "#fff",
                    IsPublic = true
                },
                new Album()
                {
                    Id = 2,
                    Name = "Qki pesni",
                    BackgroundColor = "#000",
                    IsPublic = false
                },
                new Album()
                {
                    Id = 3,
                    Name = "Skapani pesni",
                    BackgroundColor = "#696969",
                    IsPublic = true
                }
            );

            foreach (var album in context.Albums)
            {
                album.Pictures.Add(context.Pictures.Find(1));
                album.Pictures.Add(context.Pictures.Find(2));
                album.Pictures.Add(context.Pictures.Find(3));
            }
            context.SaveChanges();
        }

        private static void SeedPictures(PhotoContext context)
        {
            context.Pictures.AddOrUpdate(p => p.Id,
                new Picture()
                {
                    Id = 1,
                    Caption = "Live",
                    Title = "Lions in the city",
                    Path = "/Files/Images/lions.jpg",
                    Albums = new List<Album>()
                    {
                        context.Albums.Find(3)
                    }

                },
                  new Picture()
                  {
                      Id = 2,
                      Caption = "Drunk",
                      Title = "Drunky monkey",
                      Path = "/Files/Images/monkey.jpg",
                      Albums = new List<Album>()
                    {
                        context.Albums.Find(2)
                    }
                  },
                    new Picture()
                    {
                        Id = 3,
                        Caption = "whaaat",
                        Title = "The big poop",
                        Path = "/Files/Images/poop.jpg",
                        Albums = new List<Album>()
                        {
                            context.Albums.Find(1)
                        }
                    }
            );

            context.SaveChanges();
        }
    }
}
