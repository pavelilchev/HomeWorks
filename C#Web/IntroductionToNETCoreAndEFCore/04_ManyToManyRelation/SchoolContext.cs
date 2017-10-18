namespace _04_ManyToManyRelation
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=SchoolDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId);

            mb.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            mb.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
