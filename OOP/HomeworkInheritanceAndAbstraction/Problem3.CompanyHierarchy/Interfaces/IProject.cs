
using System;

namespace Problem3.CompanyHierarchy.Interfaces
{
	public interface IProject
	{
		void CloseProject();
		string Name { get; set; }
		DateTime StartDate { get; set; }
		string Deatails { get; set; }
	}
}
