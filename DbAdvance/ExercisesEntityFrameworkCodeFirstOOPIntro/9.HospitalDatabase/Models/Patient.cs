namespace _9.HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Medicaments = new HashSet<Medicament>();
            this.Diagnoses = new HashSet<Diagnose>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_.-]+[a-zA-Z0-9]@[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9].[a-zA-Z0-9-.]+$")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public bool HasMedicalInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }
    }
}
