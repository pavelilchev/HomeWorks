
using System;
using System.Collections.Generic;
using Problem3.CompanyHierarchy.Interfaces;
using System.Text;

namespace Problem3.CompanyHierarchy
{
	public class Manager : Employee, IManager
	{
		private List<Employee> employees;

		public Manager(int id, string firstName, string lastName, decimal salary, string departament) 
			: base(id, firstName, lastName,salary,departament)
		{
			this.employees = new List<Employee>();
		}

		public IEnumerable<Employee> Employees
        {
			get { return this.employees; }
		}

		public void AddEmployee(Employee employee)
		{
			if (employee == null)
            {
				throw new ArgumentOutOfRangeException("employee cannot be null");
			}

			this.employees.Add(employee);
            Console.WriteLine("Employee added");
		}

		public void RemoveEmployee(Employee employee)
		{
            if (this.employees.Remove(employee))
            {
                Console.WriteLine("Employee removed");
            }
            else
            {
                Console.WriteLine("No such employee");
            }
           
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("employees in teem");
            foreach (var employee in employees)
            {
                sb.Append(employee.ToString());
            }

            return sb.ToString();
        }
    }
}
