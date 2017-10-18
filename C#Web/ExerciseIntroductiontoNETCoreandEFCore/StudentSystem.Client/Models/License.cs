namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class License
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<ResourceLicense> Resources { get; set; } = new List<ResourceLicense>();
    }
}
