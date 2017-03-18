namespace Task_04.ResourceLicenses.Models
{
    using Enumerations;

    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
