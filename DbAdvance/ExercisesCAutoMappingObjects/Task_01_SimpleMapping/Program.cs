namespace Task_01_SimpleMapping
{
    using System;
    using AutoMapper;

    public class Program
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());

            var employe = new Employee()
            {
               FirstName = "Ivan",
               LastName = "Ivanov",
               Salary = 1500m,
               Birthday = new DateTime(1982, 6, 21),
               Address = "Varna"
            };

            var empDto = Mapper.Map<EmployeeDto>(employe);

            Console.WriteLine(empDto.FirstName);
            Console.WriteLine(empDto.LastName);
            Console.WriteLine(empDto.Salary);
        }
    }
}
