namespace StudentSystem.Client
{
    using System;
    using StudentSystem.Models;
    using StudentSystem.Models.Enumerations;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static Random rnd = new Random();

        public static void Main()
        {
            using (var ctx = new StudentSystemContext())
            {
                ctx.Database.EnsureCreated();
                SeedDb(ctx);
                PrintStudentsHomeworks(ctx);
                PrintCourseResourses(ctx);
                PrintCoursesWithMoreThanFiveResources(ctx);
                PrintActiveCourses(ctx);
                PrintStudentCoursesPrice(ctx);
                PrintCoursesResourcesLicenses(ctx);
                PrintStudentCoursesResources(ctx);
            }
        }

        private static void PrintStudentCoursesResources(StudentSystemContext ctx)
        {
            var result = ctx.Students
                .Select(s => new
                {
                    s.Name,
                    CoursesCounts = s.Courses.Count,
                    ResourcesCount = s.Courses.Select(c => c.Course.Resourses.Count).Sum(),
                    LicensesCount = s.Courses.Select(c => c.Course.Resourses.Select(r => r.Licenses.Count).Sum()).Sum()
                })
                .OrderByDescending(s => s.CoursesCounts)
                .ThenByDescending(s => s.ResourcesCount)
                .ThenByDescending(s => s.LicensesCount)
                .ToList();

            foreach (var s in result)
            {
                Console.WriteLine($"Name {s.Name}, Courses: {s.CoursesCounts}, Resources: {s.ResourcesCount}, Licenses: {s.LicensesCount}");
            }
        }

        private static void PrintCoursesResourcesLicenses(StudentSystemContext ctx)
        {
            var courses = ctx.Courses
                .Select(c => new
                {
                    c.Name,
                    AllResources = c.Resourses.Select(r => new
                    {
                        Name = r.Name,
                        Licenses = r.Licenses.Select(l => new
                        {
                            Name = l.License.Name
                        }).ToList()
                    })
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var c in courses)
            {
                Console.WriteLine($"Name: {c.Name}");
                foreach (var r in c.AllResources)
                {
                    Console.WriteLine($"  Resource: {r.Name}");
                    Console.WriteLine("  Licenses:");
                    foreach (var l in r.Licenses)
                    {
                        Console.WriteLine("    " + l);
                    }
                }
            }
        }

        private static void PrintStudentCoursesPrice(StudentSystemContext ctx)
        {
            var students = ctx.Students
                .Select(s => new
                {
                    s.Name,
                    CourseCount = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(sc => sc.Course.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.CourseCount)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var s in students)
            {
                Console.WriteLine($"Name: {s.Name}, Number of courses: {s.CourseCount}, Total price: {s.TotalPrice}");
            }
        }

        private static void PrintActiveCourses(StudentSystemContext ctx)
        {
            var date = DateTime.Now.AddDays(5);
            var courses = ctx.Courses
                .Where(c => c.StartDate <= date && c.EndDate >= date)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    StudentsCount = c.Students.Count,
                })
                .OrderByDescending(c=> c.StudentsCount)
                .ToList();

            foreach (var c in courses)
            {
                Console.WriteLine($"Name: {c.Name}, start: {c.StartDate}, end: {c.EndDate}, duration: {(c.EndDate - c.StartDate).Days}, students count: {c.StudentsCount}");
            }
        }

        private static void PrintCoursesWithMoreThanFiveResources(StudentSystemContext ctx)
        {
            var courses = ctx.Courses
                .Where(c => c.Resourses.Count > 5)
                .OrderBy(c => c.Resourses.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourceCount = c.Resourses.Count
                })
                .ToList();

            foreach (var c in courses)
            {
                Console.WriteLine($"Name: {c.Name}, Resource Count: {c.ResourceCount}");
            }
        }

        private static void PrintCourseResourses(StudentSystemContext ctx)
        {
            var courses = ctx.Courses
                 .OrderBy(c => c.StartDate)
                 .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resourses
                })
                .ToList();

            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Name} - {c.Description}");
                foreach (var r in c.Resourses)
                {
                    Console.WriteLine($" -Name: {r.Name}, Type: {r.ResourceType}, URL: {r.Url}");
                }
            }
        }

        private static void PrintStudentsHomeworks(StudentSystemContext ctx)
        {
            var students = ctx.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks.Select(h => new
                    {
                        h.Content,
                        h.HomeworkType
                    })
                })
                .ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                foreach (var h in student.Homeworks)
                {
                    Console.WriteLine($" -Content: {h.Content}, type: {h.HomeworkType}");
                }
            }
        }

        private static void SeedDb(StudentSystemContext ctx)
        {
            SeedCourses(ctx);
            SeedResources(ctx);
            SeedStudents(ctx);
            SeedHomeworks(ctx);
            SeedStudentCourses(ctx);

            SeedLicenses(ctx);
            SeedResourceLicenses(ctx);
        }

        private static void SeedResourceLicenses(StudentSystemContext ctx)
        {
            var licenses = ctx.Licenses.ToList();            
            var resources = ctx.Resources.ToList();      

            for (int i = 0; i < resources.Count; i++)
            {
                for (int j = 0; j < licenses.Count; j++)
                {
                    var check = rnd.Next(10);
                    if (check > 8)
                    {
                        resources[i].Licenses.Add(new ResourceLicense()
                        {
                            LicenseId = licenses[j].Id
                        });
                    }
                }
            }

            ctx.SaveChanges();
        }

        private static void SeedLicenses(StudentSystemContext ctx)
        {
            for (int i = 0; i < 40; i++)
            {
                ctx.Licenses.Add(new License()
                {
                    Name = $"License {i}"
                });
            }

            ctx.SaveChanges();
        }

        private static void SeedStudentCourses(StudentSystemContext ctx)
        {
            var courses = ctx.Courses.ToList();
            var students = ctx.Students.ToList();
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    var check = rnd.Next(10);
                    if(check > 7)
                    {
                        students[i].Courses.Add(new StudentCourses()
                        {
                            CourseId = courses[j].Id
                        });
                    }
                }
            }

            ctx.SaveChanges();
        }

        private static void SeedHomeworks(StudentSystemContext ctx)
        {
            var courses = ctx.Courses.ToList();
            var students = ctx.Students.ToList();
            for (int i = 0; i < 60; i++)
            {
                var cId = rnd.Next(courses.Count);
                var sId = rnd.Next(students.Count);
                var home = new Homework()
                {
                    Content = $"Content {i}",
                    CourseId = courses[cId].Id,
                    HomeworkType = (HomeworkType)(i % 3),
                    StudentId = students[sId].Id,
                    SubmissionDate = DateTime.Now.AddDays(i)
                };

                ctx.Homeworks.Add(home);
            }

            ctx.SaveChanges();
        }

        private static void SeedCourses(StudentSystemContext ctx)
        {
            for (int i = 0; i < 10; i++)
            {
                var course = new Course()
                {
                    Description = $"This is course for {i}",
                    EndDate = DateTime.Now.AddMonths(i),
                    Name = $"Course {i}",
                    Price = 100 + (i / 0.1m),
                    StartDate = DateTime.Now.AddDays(i)
                };

                ctx.Courses.Add(course);
            }

            ctx.SaveChanges();
        }

        private static void SeedResources(StudentSystemContext ctx)
        {
            var courses = ctx.Courses.ToList();

            for (int i = 0; i < 60; i++)
            {
                var resource = new Resource()
                {
                    Name = $"Resource {i}",
                    ResourceType = (ResourceType)(i % 4),
                    CourseId = courses[i % courses.Count].Id,
                    Url = $"softuni.bg/resources/{i}"
                };             

                ctx.Resources.Add(resource);
            }

            ctx.SaveChanges();
        }

        private static void SeedStudents(StudentSystemContext ctx)
        {
            for (int i = 0; i < 20; i++)
            {
                var student = new Student()
                {
                    Name = $"Student {i}",
                    Birthday = DateTime.Now.AddYears(-(18 + i)),
                    PhoneNumber = $"0123456789{i}",
                    RegistrationDate = DateTime.Now.AddDays(-i)
                };

                ctx.Students.Add(student);
            }

            ctx.SaveChanges();
        }
    }
}
