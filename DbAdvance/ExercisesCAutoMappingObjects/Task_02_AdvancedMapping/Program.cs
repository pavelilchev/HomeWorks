namespace Task_02_AdvancedMapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;

    public class Program
    {
        public static void Main()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();

                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(dest => dest.Subordinates,
                        opt => opt.MapFrom(
                        src => Mapper.Map<List<EmployeeDto>>(src.Subordinates)))
                    .ForMember(opt => opt.SubordinatesCount,
                        opt => opt.MapFrom(
                        src => src.Subordinates.Count));
            });

            var steve = new Employee()
            {
                FirstName = "Steve",
                LastName = "Jobbsen",
                Salary = 200000m,
                Birthday = DateTime.Now.AddYears(-40),
                Address = "Sky",
                HolidayPlace = "Paradise"
            };

            var emp1 = new Employee()
            {
                FirstName = "Stephen",
                LastName = "Bjorn",
                Salary = 4300m,
                Birthday = DateTime.Now.AddYears(-30),
                Manager = steve
            };

            var emp2 = new Employee()
            {
                FirstName = "Kirilyc",
                LastName = "Lefi",
                Salary = 4400m,
                Birthday = DateTime.Now.AddYears(-33),
                Manager = steve
            };

            steve.Subordinates.AddRange(new[] { emp1, emp2 });

            var carl = new Employee()
            {
                FirstName = "Carl",
                LastName = "Kormac",
                Salary = 199000m,
                Birthday = DateTime.Now.AddYears(-40),
                Address = "There",
                HolidayPlace = "Here"
            };

            var emp3 = new Employee()
            {
                FirstName = "Jurgen",
                LastName = "Straus",
                Salary = 1000.45m,
                Birthday = DateTime.Now.AddYears(-30),
                Manager = carl
            };

            var emp4 = new Employee()
            {
                FirstName = "Moni",
                LastName = "Kozinac",
                Salary = 2030.99m,
                Birthday = DateTime.Now.AddYears(-30),
                Manager = carl
            };

            var emp5 = new Employee()
            {
                FirstName = "Kopp",
                LastName = "Spidok",
                Salary = 2000.21m,
                Birthday = DateTime.Now.AddYears(-30),
                Manager = carl
            };

            carl.Subordinates.AddRange(new[] { emp3, emp4, emp5 });

            var employees = new List<Employee>()
            {
                steve,carl,emp1,emp2,emp3,emp4,emp5
            };

            var managerDtos = Mapper.Map<List<ManagerDto>>(employees.Where(e => e.Subordinates.Count > 0));

            foreach (var m in managerDtos)
            {
                Console.WriteLine($"{m.FirstName} {m.LastName} | Employees: {m.SubordinatesCount}");
                foreach (var s in m.Subordinates)
                {
                    Console.WriteLine($"   - {s.FirstName} {s.LastName} {s.Salary}");
                }
            }
        }
    }
}
