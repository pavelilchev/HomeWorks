
using System;

namespace Problem3StringDisperser
{
	public class StringDisperserMain
	{
		public static void Main(string[] args)
		{
			StringDisperser sd1 = new StringDisperser("Pavel", "Ilchev");
			StringDisperser sd2 = new StringDisperser("Natali", "Nikolova");
			
			Console.WriteLine(sd1 == sd2);
			
			StringDisperser copy = sd1.Clone();
			
			foreach (var s in sd1) 
			{
				Console.Write(s + " ");
			}
			
			Console.ReadKey(true);
		}
	}
}