﻿namespace _9.HospitalDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
