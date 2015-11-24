
using System;

namespace Problem3.CompanyHierarchy
{
	public abstract class RegularEmployee : Employee
	{
		public RegularEmployee(int id, string firstName, string lastName, decimal salary, string departament)
			: base(id, firstName, lastName,salary,departament)
		{
	
		}		
	}
}
