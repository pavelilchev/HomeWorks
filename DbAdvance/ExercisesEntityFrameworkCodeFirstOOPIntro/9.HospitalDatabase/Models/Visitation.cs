namespace _9.HospitalDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public int Id { get; set; }

        [Required]
        public DateTime VisitationDate { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Comments { get; set; }
    }
}
