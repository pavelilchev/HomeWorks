namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using Utilities;

    public class UploadPictureCommand : Command
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];

            using (PhotoShareContext ctx = new PhotoShareContext())
            {
                var album = ctx.Albums.FirstOrDefault(a => a.Name == albumName);
                if (album == null)
                {
                    throw new ArgumentException($"Album {albumName} not found!");
                }

                var pic = new Picture()
                {
                    Title = pictureTitle,
                    Path = pictureFilePath
                };

                album.Pictures.Add(pic);
                ctx.SaveChanges();

                return $"Picture {pictureTitle} added to {albumName}!";
            }
        }
    }
}
