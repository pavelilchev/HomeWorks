namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Utilities;

    public class CreateAlbumCommand : Command
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length < 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];
            string[] tags = data.Skip(3).ToArray();

            using (var ctx = new PhotoShareContext())
            {
                var user = ctx.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (ctx.Albums.Any(a => a.Name == albumTitle))
                {
                    throw new ArgumentException($"Album {albumTitle} exists!");
                }

                Color color;
                if (!Enum.TryParse(bgColor, out color))
                {
                    throw new ArgumentException($"Color {bgColor} not found!");
                }

                var allTags = ctx.Tags.ToList();
                var albumTags = new List<Tag>();
                foreach (var tag in tags)
                {
                    var currentTag = allTags.FirstOrDefault(t => t.Name == tag.ValidateOrTransform());
                    if (currentTag == null)
                    {
                        throw new ArgumentException($"Invalid tags!");
                    }
                    albumTags.Add(currentTag);
                }

                var album = new Album()
                {
                    Name = albumTitle,
                    BackgroundColor = color,
                    Tags = albumTags
                };

                var albumRole = new AlbumRole()
                {
                    Album = album,
                    User = user,
                    Role = Role.Owner
                };

                //album.AlbumRoles.Add(albumRole);
                //user.AlbumRoles.Add(albumRole);

                ctx.Albums.Add(album);
                ctx.AlbumRoles.Add(albumRole);
                ctx.SaveChanges();
            }

            return $"Album {albumTitle} successfully created!";
        }
    }
}
