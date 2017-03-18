namespace Task_01.CodeFirstStudentSystem
{
    using System.Data.Entity;
    using Models;

    public class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext()
            : base("name=StudentsSystemContext")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }
    }
}