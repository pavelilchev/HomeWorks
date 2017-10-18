namespace SocialNetwork
{
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Data;
    using SocialNetwork.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            using (var ctx = new SocialNetworkContext())
            {
                //ctx.Database.Migrate();
                //SeedUsers(ctx);
                //SeedFriends(ctx);
                //SeedAlbums(ctx);
                //SeedPictures(ctx);
                //AddPicturesToAlbums(ctx);
                //PrintUsersFriends(ctx);
                //PrintActiveUsers(ctx);
                //PrintAlbumsOwners(ctx);
                //PrintPopularPictures(ctx);
                //PrintUserAlbums(ctx);
            }
        }

        private static void PrintUserAlbums(SocialNetworkContext ctx)
        {
            var userId = ctx.Users.Select(u => u.Id).FirstOrDefault();
            var albums = ctx.Albums
                .Where(a => a.OwnerId == userId)
                .Select(a => new
                {
                    Owner = a.Owner.Username,
                    a.IsPublic,
                    a.Name,
                    Pictures = a.Pictures.Select(p => new
                    {
                        Title = p.Picture.Title,
                        Path = p.Picture.Path
                    })
                });

            foreach (var a in albums)
            {
                Console.WriteLine($"Owner: {a.Owner}");
                if (a.IsPublic)
                {
                    Console.WriteLine($"Album: {a.Name}");
                    Console.WriteLine($"Pictures");
                    foreach (var p in a.Pictures)
                    {
                        Console.WriteLine($"{p.Title} - {p.Path}");
                    }
                }
                else
                {
                    Console.WriteLine("Private content!");
                }

                Console.WriteLine();
            }
        }

        private static void PrintPopularPictures(SocialNetworkContext ctx)
        {
            var pictures = ctx.Pictures
                .Where(p => p.Albums.Count > 2)
                .Select(p => new
                {
                    p.Title,
                    Albums = p.Albums.Select(a => new
                    {
                        Name = a.Album.Name,
                        Owner = a.Album.Owner.Username
                    }).ToList()
                })
                .OrderByDescending(a => a.Albums.Count)
                .ThenBy(a => a.Title)
                .ToList();

            foreach (var p in pictures)
            {
                Console.WriteLine(p.Title);
                foreach (var a in p.Albums)
                {
                    Console.WriteLine($"-{a.Name} - {a.Owner}");
                }
            }
        }

        private static void PrintAlbumsOwners(SocialNetworkContext ctx)
        {
            var result = ctx.Albums
                .Select(a => new
                {
                    a.Name,
                    Owner = a.Owner.Username,
                    Pictures = a.Pictures.Count
                })
                .OrderByDescending(a => a.Pictures)
                .ThenBy(a => a.Owner)
                .ToList();

            foreach (var a in result)
            {
                Console.WriteLine($"{a.Name} - {a.Owner}, Pictures: {a.Pictures}");
            }
        }

        private static void AddPicturesToAlbums(SocialNetworkContext ctx)
        {
            var pictures = ctx.Pictures.ToList();
            var albumsId = ctx.Albums.Select(a => a.Id).ToList();
            foreach (var picture in pictures)
            {
                var albumCount = rnd.Next(albumsId.Count / 4);
                var addedAlbumsId = new HashSet<int>();
                for (int i = 0; i < albumCount; i++)
                {
                    var albumId = albumsId[rnd.Next(albumsId.Count)];
                    addedAlbumsId.Add(albumId);
                }

                foreach (var id in addedAlbumsId)
                {
                    picture.Albums.Add(new PictureAlbum()
                    {
                        AlbumId = id
                    });
                }
            }

            ctx.SaveChanges();
        }

        private static void SeedPictures(SocialNetworkContext ctx)
        {
            for (int i = 0; i < 200; i++)
            {
                ctx.Pictures.Add(new Picture()
                {
                    Caption = $"Caption {i}",
                    Path = $"Path {i}",
                    Title = $"Title{i}"
                });
            }

            ctx.SaveChanges();
        }

        private static void SeedAlbums(SocialNetworkContext ctx)
        {
            var usersId = ctx.Users.Select(u => u.Id).ToList();
            for (int i = 0; i < 100; i++)
            {
                ctx.Albums.Add(new Album()
                {
                    BackgroundColor = $"{rnd.Next(256)},{rnd.Next(256)},{rnd.Next(256)}",
                    IsPublic = rnd.Next(2) == 0 ? true : false,
                    Name = $"Album {i}",
                    OwnerId = usersId[rnd.Next(usersId.Count)]
                });
            }

            ctx.SaveChanges();
        }

        private static void PrintActiveUsers(SocialNetworkContext ctx)
        {
            var result = ctx.Users
                .Where(u => !u.IsDeleted && u.FriendsFirst.Count > 5)
                .OrderBy(u => u.RegistredOn)
                .ThenBy(u => u.FriendsFirst.Count)
                .Select(u => new
                {
                    u.Username,
                    Friends = u.FriendsFirst.Count,
                    Period = DateTime.Now.Subtract(u.RegistredOn)
                })
                .ToList();

            foreach (var u in result)
            {
                Console.WriteLine($"{u.Username}, Friends: {u.Friends}, Period: {u.Period.TotalDays}");
            }
        }

        private static void PrintUsersFriends(SocialNetworkContext ctx)
        {
            var result = ctx.Users
                .Select(u => new
                {
                    u.Username,
                    u.IsDeleted,
                    Friends = u.FriendsFirst.Count
                })
                .OrderByDescending(u => u.Friends)
                .ThenBy(u => u.Username)
                .ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Username}, Friends: {user.Friends}, Status: {(user.IsDeleted ? "Inactive" : "Active")}");
            }
        }

        private static void SeedFriends(SocialNetworkContext ctx)
        {
            var users = ctx.Users.ToList();
            foreach (var user in users)
            {
                var friendsCount = rnd.Next(users.Count / 2);
                var addedFriendsIds = new HashSet<int>();
                for (int i = 0; i < friendsCount; i++)
                {
                    var secondId = users[rnd.Next(users.Count)].Id;
                    while (user.Id == secondId)
                    {
                        secondId = users[rnd.Next(users.Count)].Id;
                    }

                    addedFriendsIds.Add(secondId);
                }

                foreach (var addedId in addedFriendsIds)
                {
                    user.FriendsFirst.Add(new UserFriend()
                    {
                        UserSecondId = addedId
                    });
                }
            }

            ctx.SaveChanges();
        }

        private static void SeedUsers(SocialNetworkContext ctx)
        {
            for (int i = 0; i < 50; i++)
            {
                ctx.Users.Add(new User()
                {
                    Age = rnd.Next(18, 100),
                    Email = $"email_{i}@gmail.com",
                    IsDeleted = rnd.Next(3) == 0 ? true : false,
                    LastTimeLoggedIn = DateTime.Now.AddDays(-rnd.Next(0, 360)),
                    Password = $"sOm3pass!{i}",
                    ProfilePicture = new byte[i],
                    RegistredOn = DateTime.Now.AddMonths(-rnd.Next(1, 12)),
                    Username = $"username{i}"
                });
            }

            ctx.SaveChanges();
        }
    }
}
