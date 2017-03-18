namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Utilities;

    public class AddTagToCommand : Command
    {
        // AddTagTo <albumName> <tag>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string albumName = data[0];
            string tagName = data[1].ValidateOrTransform();

            using (var ctx = new PhotoShareContext())
            {
                var album = ctx.Albums.FirstOrDefault(a => a.Name == albumName);
                var tag = ctx.Tags.FirstOrDefault(t => t.Name == tagName);
                if (album == null || tag == null)
                {
                    throw new ArgumentException("Either tag or album do not exist!");
                }

                album.Tags.Add(tag);
                ctx.SaveChanges();
            }

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
