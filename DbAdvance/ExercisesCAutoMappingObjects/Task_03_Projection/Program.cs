namespace Task_03_Projection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class Program
    {
        public static void Main()
        {
            var ctx = new  EmployeeContext();
            ctx.Database.Initialize(true);


            Mapper.Initialize(cfg => 
            cfg.CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.ManagerLastName,
            dto => dto.MapFrom(src => src.Manager.LastName)));

          
            var employeeDtos = ctx.Employees.Where(e => e.Birthday.Year < 1990 ).OrderByDescending(e => e.Salary).ProjectTo<EmployeeDto>().ToList();
           
            foreach (var employeeDto in employeeDtos)
            {
                Console.WriteLine(employeeDto);
            }
        }
    }
}
