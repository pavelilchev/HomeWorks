
using System;
using System.Collections.Generic;

namespace Problem3.CompanyHierarchy.Interfaces
{
	public interface IManager
	{
		void AddEmployee(Employee employee);
		void RemoveEmployee(Employee employee);
		IEnumerable<Employee> Employees { get; }
	}
}
