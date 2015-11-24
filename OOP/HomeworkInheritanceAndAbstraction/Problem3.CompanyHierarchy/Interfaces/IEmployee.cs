
using System;

namespace Problem3.CompanyHierarchy.Interfaces
{
	public interface IEmployee
	{
		decimal Salary { get; set; }
		Departament Departament { get; set; }
	}
}
