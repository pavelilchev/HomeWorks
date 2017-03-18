namespace _10.HospitalDatabaseModification.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Speciality { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
