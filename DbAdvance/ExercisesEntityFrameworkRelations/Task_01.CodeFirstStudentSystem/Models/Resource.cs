namespace Task_01.CodeFirstStudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enumerations;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string URL { get; set; }

        public virtual Course Course { get; set; }
    }
}
