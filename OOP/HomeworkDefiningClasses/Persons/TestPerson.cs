
using System;

namespace Persons
{
	public class TestPerson
	{
		public static void Main()
		{
		Person az = new Person("Pavel", 33, "pavel_ilchev@abv.bg");
		Person ti = new Person("Natali", 28);
		
		Console.WriteLine(az);
		Console.WriteLine(ti);
		
		}
	}
}
