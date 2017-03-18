namespace Photo.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        [Index(IsUnique = true)]
        [Utils.CustomAttributes.Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}