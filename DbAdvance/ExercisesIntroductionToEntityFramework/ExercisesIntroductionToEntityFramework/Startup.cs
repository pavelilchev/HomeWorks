namespace ExercisesIntroductionToEntityFramework
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Models;

    public class Startup
    {
        static readonly SoftUniContext Data = new SoftUniContext();

        public static void Main()
        {


            var timer = new Stopwatch();
            timer.Start();
            Native();
            timer.Stop();
            Console.WriteLine(timer.Elapsed);

            timer.Restart();
            Linq();
            timer.Stop();
            Console.WriteLine(timer.Elapsed);

            Console.ReadKey();
        }

        private static void Linq()
        {
            var employees =
                Data.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                    .Select(e => e.FirstName)
                    .ToList();

            Console.WriteLine(employees.Count);
        }

        private static void Native()
        {
            var employees = Data.Employees.SqlQuery(@"select distinct e.EmployeeID from Employees e
join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID
where DATEPART(year, p.StartDate) = 2002").ToList();

            Console.WriteLine(employees.Count);
        }
    }
}
