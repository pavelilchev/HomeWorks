namespace Photo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PhotographerAlbums
    {
        [Column(Order = 0), Key, ForeignKey("Photographer")]
        public int PhotographerId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Album")]
        public int AlbumId { get; set; }

        public virtual Photographer Photographer { get; set; }

        public virtual Album Album { get; set; }

        public Role Role { get; set; }
    }
}
