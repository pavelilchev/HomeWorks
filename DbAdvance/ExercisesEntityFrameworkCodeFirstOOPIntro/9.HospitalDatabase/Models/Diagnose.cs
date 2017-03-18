namespace _9.HospitalDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(2000, MinimumLength = 2)]
        public string Comments { get; set; }
    }
}
