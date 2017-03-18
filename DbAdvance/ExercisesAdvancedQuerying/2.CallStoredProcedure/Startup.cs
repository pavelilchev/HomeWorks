namespace _2.CallStoredProcedure
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var ctx = new SoftuniContext();

            //2. Call a Stored Procedure
            CallStoredProcedure(ctx);

            //3. Employees Maximum Salaries
            GetDepartmentsMaxSalary(ctx);
        }

        private static void GetDepartmentsMaxSalary(SoftuniContext ctx)
        {
            var deps = ctx.Departments
                .Select(d => new
                {
                    d.Name,
                    MaxSalary = d.Employees
                        .Max(e => e.Salary)
                })
                .Where(d => d.MaxSalary < 30000 || d.MaxSalary > 70000)
                .ToList();

            foreach (var d in deps)
            {
                Console.WriteLine($"{d.Name} - {d.MaxSalary:f2}");
            }
        }

        private static void CallStoredProcedure(SoftuniContext ctx)
        {
            Console.Write("Enter employee first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter employee last name: ");
            string lastName = Console.ReadLine();

            var firstNameParam = new SqlParameter
            {
                ParameterName = "firstName",
                Value = firstName
            };

            var lastNameParam = new SqlParameter
            {
                ParameterName = "lastName",
                Value = lastName
            };


            var projects =
                ctx.Database.SqlQuery<Project>("sp_GetAllProjectsByEmployee @firstName, @lastName", firstNameParam,
                    lastNameParam).ToList();
            foreach (var p in projects)
            {
                Console.WriteLine($"{p.Name} - {p.Description} - {p.StartDate}");
            }

            /* create proc sp_GetAllProjectsByEmployee
            @firstName varchar(max), @lastName varchar(max)
            as begin

            select p.ProjectID,p.Name,p.Description,p.EndDate,p.StartDate from Employees e
            join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID
            join Projects p on ep.ProjectID = p.ProjectID
            where e.FirstName = @firstName and e.LastName = @lastName

            end */
        }
    }
}