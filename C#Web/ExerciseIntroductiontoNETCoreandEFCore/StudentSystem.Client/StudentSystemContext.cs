namespace StudentSystem.Client
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Models;

    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<License> Licenses  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.;Database=StudentSystemDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<StudentCourses>()
                  .HasKey(sc => new { sc.StudentId, sc.CourseId });

            mb.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId);


            mb.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            mb.Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.Homeworks)
                .HasForeignKey(h => h.StudentId);

            mb.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.Homeworks)
                .HasForeignKey(h => h.CourseId);

            mb.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resourses)
                .HasForeignKey(r => r.CourseId);

            mb.Entity<ResourceLicense>()
                .HasKey(rl => new { rl.ResourceId, rl.LicenseId });

            mb.Entity<Resource>()
                .HasMany(r => r.Licenses)
                .WithOne(rl => rl.Resource)
                .HasForeignKey(rl => rl.ResourceId);

            mb.Entity<License>()
                .HasMany(l => l.Resources)
                .WithOne(rl => rl.License)
                .HasForeignKey(rl => rl.LicenseId);
        }
    }
}
