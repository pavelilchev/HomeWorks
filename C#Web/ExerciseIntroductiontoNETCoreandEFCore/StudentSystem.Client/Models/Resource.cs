namespace StudentSystem.Models
{
    using StudentSystem.Models.Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Url { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public List<ResourceLicense> Licenses { get; set; } = new List<ResourceLicense>();
    }
}
