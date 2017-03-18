namespace Task_03.WorkingWithTheDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Models.Enumerations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "Task_03.WorkingWithTheDatabase.StudentsSystemContext";
        }

        protected override void Seed(StudentsSystemContext context)
        {
            SeedStudents(context);
            SeedCourses(context);
            SeedHomeworks(context);
            SeedResources(context);
        }

        private static void SeedHomeworks(StudentsSystemContext context)
        {
            var hw1 = new Homework()
            {
                Id = 1,
                Content = "Neshto slojno",
                ContentType = ContentType.Zip,
                Student = context.Students.Find(1),
                Course = context.Courses.Find(1)
            };

            var hw2 = new Homework()
            {
                Id = 2,
                Content = "Drugo slojno",
                ContentType = ContentType.Application,
                Student = context.Students.Find(2),
                Course = context.Courses.Find(2)
            };

            var hw3 = new Homework()
            {
                Id = 3,
                Content = "Nai-slojno",
                ContentType = ContentType.Pdf,
                Student = context.Students.Find(3),
                Course = context.Courses.Find(3)
            };

            context.Homeworks.AddOrUpdate(hw1, hw2, hw3);
            context.SaveChanges();
        }

        private static void SeedResources(StudentsSystemContext context)
        {
            var resource1 = new Resource()
            {
                Id = 1,
                Name = "Pomagalo",
                ResourceType = ResourceType.Document,
                URL = "/files/pomagalo.doc",
                Course = context.Courses.Find(1)
            };

            var resource2 = new Resource()
            {
                Id = 2,
                Name = "Presentalo",
                ResourceType = ResourceType.Presentation,
                URL = "/files/Presentalo.ppx",
                Course = context.Courses.Find(2)
            };

            var resource3 = new Resource()
            {
                Id = 3,
                Name = "Gledalo1",
                ResourceType = ResourceType.Video,
                URL = "/files/Gledalo.mp4",
                Course = context.Courses.Find(3)
            };

            var resource4 = new Resource()
            {
                Id = 4,
                Name = "Gledalo2",
                ResourceType = ResourceType.Video,
                URL = "/files/Gledalo.mp4",
                Course = context.Courses.Find(3)
            };

            var resource5 = new Resource()
            {
                Id = 5,
                Name = "Gledalo3",
                ResourceType = ResourceType.Video,
                URL = "/files/Gledalo.mp4",
                Course = context.Courses.Find(3)
            };


            var resource6= new Resource()
            {
                Id =6,
                Name = "Gledalo4",
                ResourceType = ResourceType.Video,
                URL = "/files/Gledalo.mp4",
                Course = context.Courses.Find(3)
            };

            var resource7 = new Resource()
            {
                Id = 7,
                Name = "Gledalo5",
                ResourceType = ResourceType.Video,
                URL = "/files/Gledalo.mp4",
                Course = context.Courses.Find(3)
            };

            var resource8 = new Resource()
            {
                Id = 8,
                Name = "Gledalo6",
                ResourceType = ResourceType.Video,
                URL = "/files/Gledalo.mp4",
                Course = context.Courses.Find(3)
            };


            context.Resources.AddOrUpdate(resource1, resource2, resource3,resource4,resource5,resource6,resource7,resource8);
            context.SaveChanges();
        }

        private static void SeedStudents(StudentsSystemContext context)
        {
            var student1 = new Student()
            {
                Id = 1,
                Name = "Kitarista",
                RegistrationDate = DateTime.Now
            };

            var student2 = new Student()
            {
                Id = 2,
                Name = "Barabanista",
                RegistrationDate = DateTime.Now.AddDays(-1),
                PhoneNumber = "052305944",
                Birthday = new DateTime(1981, 11, 04)
            };

            var student3 = new Student()
            {
                Id = 3,
                Name = "Vokala",
                RegistrationDate = DateTime.Now.AddMonths(-1)
            };

            context.Students.AddOrUpdate(student1, student2, student3);
            context.SaveChanges();
        }

        private static void SeedCourses(StudentsSystemContext context)
        {
            var course1 = new Course()
            {
                Id = 1,
                Name = "Osnovi na EF",
                Description = "Uchish Osnovi na EF",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 04, 20),
                Price = 290m,
                Students = context.Students.ToList(),
                Homeworks = context.Homeworks.ToList(),
                Resources = context.Resources.ToList()
            };

            var course2 = new Course()
            {
                Id = 2,
                Name = "EF Advance",
                Description = "Uchish oshte EF",
                StartDate = new DateTime(2017, 05, 17),
                EndDate = new DateTime(2017, 07, 20),
                Price = 390m,
                Students = context.Students.ToList(),
                Homeworks = context.Homeworks.ToList(),
                Resources = context.Resources.ToList()
            };

            var course3 = new Course()
            {
                Id = 3,
                Name = "Master EF",
                Description = "Stavash magiosnik na EF",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 10, 20),
                Price = 490m,
                Students = context.Students.ToList(),
                Homeworks = context.Homeworks.ToList(),
                Resources = context.Resources.ToList()
            };


            context.Courses.AddOrUpdate(course1, course2, course3);
            context.SaveChanges();
        }
    }
}
