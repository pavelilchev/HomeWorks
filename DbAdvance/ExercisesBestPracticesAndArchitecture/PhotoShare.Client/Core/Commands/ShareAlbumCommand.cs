namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using Utilities;

    public class ShareAlbumCommand : Command
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            int id;
            int.TryParse(data[0], out id);
            string username = data[1];
            string permission = data[2];


            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = context.Albums.Find(id);
                if (album == null)
                {
                    throw new ArgumentException($"Album {id} not found!");
                }

                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (Engine.User == null || Engine.User.Username != user.Username || album.AlbumRoles.Any(r=>r.User.Username == user.Username && r.Role == Role.Owner))
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }

                Role role;
                if (!Enum.TryParse(permission, out role))
                {
                    throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
                }

                var albumRole = new AlbumRole()
                {
                    Album = album,
                    User = user,
                    Role = role
                };

                context.AlbumRoles.Add(albumRole);
                context.SaveChanges();

                return $"Username {username} added to album {album.Name} ({permission})";
            }
        }
    }
}
