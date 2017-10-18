namespace SocialNetwork.Models
{
    using System.Collections.Generic;

    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public List<PictureAlbum> Pictures { get; set; } = new List<PictureAlbum>();

        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
