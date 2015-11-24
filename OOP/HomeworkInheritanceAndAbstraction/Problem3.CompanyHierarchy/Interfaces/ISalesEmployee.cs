
using System;
using System.Collections.Generic;

namespace Problem3.CompanyHierarchy.Interfaces
{
	public interface ISalesEmployee
	{
		void AddSale(Sale sale);
		void RemoveSale(Sale sale);
		IEnumerable<Sale> Sales { get; }
	}
}
