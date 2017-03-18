namespace Task_04.ResourceLicenses
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext()
             : base("name=StudentsSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<License> Licenses { get; set; }
    }
}