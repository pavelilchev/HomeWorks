
using System;
using System.Collections.Generic;

namespace Problem2Customer
{
	public class CustomerMain
	{
		public static void Main(string[] args)
		{
			Payment fp = new Payment("Himikal", 2m);
			Payment sp = new Payment("tefter", 3m);
			List<Payment> firstPayments = new List<Payment>();
			firstPayments.Add(fp);
			List<Payment> secondPayments = new List<Payment>();
			secondPayments.Add(sp);
			
			Customer first = new Customer("Pavel", "Veselinov", "Ilchev", "8206211125", "Varna", "577160",
			                              "pavel@abv.bg", firstPayments, CustomerType.Diamond);
				
			Customer second = new Customer("Natalia", "Krasimirova", "Nikolova", "8804151312", "Varna", "560250",
			                              "nati@abv.bg", secondPayments, CustomerType.Golden);
			
			Customer copy = first.Clone();
			
			copy.Payments.Add(new Payment("test", 4.5m));
			
			Console.WriteLine(first);
				
			Console.WriteLine(copy);
			
			Console.WriteLine(first.CompareTo(second));
			
			Console.ReadKey(true);
		}
	}
}