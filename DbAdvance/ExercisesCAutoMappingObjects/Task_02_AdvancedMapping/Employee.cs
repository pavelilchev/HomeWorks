namespace Task_02_AdvancedMapping
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new List<Employee>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string HolidayPlace { get; set; }

        public Employee Manager { get; set; }

        public List<Employee> Subordinates { get; set; }
    }
}
