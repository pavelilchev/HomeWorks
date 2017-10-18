namespace StudentSystem.Models
{
    public class ResourceLicense
    {
        public int ResourceId { get; set; }

        public Resource Resource { get; set; }

        public int LicenseId { get; set; }

        public License License { get; set; }
    }
}
