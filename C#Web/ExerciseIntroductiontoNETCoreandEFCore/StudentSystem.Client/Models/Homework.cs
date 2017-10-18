namespace StudentSystem.Models
{
    using StudentSystem.Models.Enumerations;
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
