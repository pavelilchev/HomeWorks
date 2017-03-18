﻿namespace Task_04.ResourceLicenses.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enumerations;

    public class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string URL { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
