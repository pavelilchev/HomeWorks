namespace Task_03.WorkingWithTheDatabase
{
    using System;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var ctx = new StudentsSystemContext();
            Console.WriteLine(@"Enter:
1 - all Students
2 - all Courses
3 - courses with more than 5 resources
4 - courses active on given date
5 - students details
end - for exit");
            Console.Write("Enter command: ");
            string comand = Console.ReadLine();
            while (comand != "end")
            {
                switch (comand)
                {
                    case "1":
                        ListAllStudents(ctx);
                        break;
                    case "2":
                        ListAllCourses(ctx);
                        break;
                    case "3":
                        ListCoursesMoreThan5Resources(ctx);
                        break;
                    case "4":
                        Console.Write("Enter date in format dd.mm.yyyy (e.g. 18.02.2017): ");
                        var dateString = Console.ReadLine();
                        DateTime date;
                        bool isDate = DateTime.TryParse(dateString, out date);
                        while (!isDate)
                        {
                            Console.Write("Invalid date, try again: ");
                            dateString = Console.ReadLine();
                            isDate = DateTime.TryParse(dateString, out date);
                        }
                        ListActiveCourses(ctx, date);
                        break;
                    case "5":
                        ListStudentsDetails(ctx);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

                Console.Write("Enter command: ");
                comand = Console.ReadLine();
            }
        }

        private static void ListStudentsDetails(StudentsSystemContext ctx)
        {
            var students = ctx.Students
                .Select(s => new
                {
                    s.Name,
                    CoursesCount = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price)
                })
                .OrderByDescending(s => s.TotalPrice)
                .ThenByDescending(s => s.CoursesCount)
                .ThenBy(s => s.Name)
                .ToList();


            if (students.Count == 0)
            {
                Console.WriteLine("No students found!");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, courses count: {student.CoursesCount} for total {student.TotalPrice}");
            }
        }

        private static void ListActiveCourses(StudentsSystemContext ctx, DateTime date)
        {
            var courses = ctx.Courses
                .Where(c => c.StartDate < date && c.EndDate > date)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = SqlFunctions.DateDiff("day", c.StartDate, c.EndDate),
                    StudentsCount = c.Students.Count
                })
                .OrderByDescending(c => c.StudentsCount)
                .ThenByDescending(c => c.Duration)
                .ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("No active courses found!");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - from {course.StartDate:dd.MM.yyy} to {course.EndDate:dd.MM.yyy}, total {course.Duration} days, students enrolled: {course.StudentsCount}");
            }
        }

        private static void ListCoursesMoreThan5Resources(StudentsSystemContext ctx)
        {
            var courses = ctx.Courses
                .Where(c => c.Resources.Count > 5)
                .Select(c => new
                {
                    c.Name,
                   Count = c.Resources.Count,
                   c.StartDate
                })
                .OrderByDescending(c => c.Count)
                .ThenByDescending(c => c.StartDate)
                .ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses with more tha 5 resourses found!");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Count}");
            }
        }

        private static void ListAllCourses(StudentsSystemContext ctx)
        {
            var courses = ctx.Courses
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources,
                    c.StartDate,
                    c.EndDate
                })
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found!");
                return;
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Description}");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"  --{resource.Name}, {resource.ResourceType}, {resource.URL}");
                }
            }
        }

        private static void ListAllStudents(StudentsSystemContext ctx)
        {
            var students = ctx.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks.Select(h => new
                    {
                        h.Content,
                        h.ContentType
                    })
                })
                .ToList();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found!");
                return;
            }


            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($"  --{homework.Content} - {homework.ContentType}");
                }
            }
        }
    }
}
