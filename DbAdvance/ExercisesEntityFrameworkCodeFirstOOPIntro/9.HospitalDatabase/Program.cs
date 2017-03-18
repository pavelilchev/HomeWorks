namespace _9.HospitalDatabase
{
    using System;
    using Models;

    public class Program
    {
        public static void Main()
        {
            var ctx = new HospitalContext();
            var diagnose = new Diagnose()
            {
                Name = "Lupos",
                Comments = "Nikoga ne e lupos!"
            };

            var visitation = new Visitation()
            {
                VisitationDate = DateTime.Now,
                Comments = "Some comment..."
            };

            var medicament = new Medicament()
            {
                Name = "Tribestan"
            };

            var patient = new Patient()
            {
                Address = "Gurkovo, Purva str, 24",
                BirthDate = new DateTime(2000,1,1),
                Email = "bat@bandit.com",
                FirstName = "Bat",
                LastName = "Bandit",
                HasMedicalInsurance = false
            };

           
            patient.Diagnoses.Add(diagnose);
            patient.Medicaments.Add(medicament);
            patient.Visitations.Add(visitation);
            ctx.Patients.Add(patient);

            ctx.SaveChanges();
        }
    }
}
