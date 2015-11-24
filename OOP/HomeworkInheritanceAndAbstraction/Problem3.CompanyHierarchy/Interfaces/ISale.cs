
using System;

namespace Problem3.CompanyHierarchy.Interfaces
{
	public interface ISale
	{
		DateTime Date { get; set; }
		decimal Price { get; set; }
		string Name { get; set; }
	}
}
