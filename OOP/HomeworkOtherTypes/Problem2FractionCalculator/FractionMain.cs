
using System;

namespace Problem2FractionCalculator
{
	class FractionMain
	{
		public static void Main(string[] args)
		{
			
			Fraction tree = new Fraction(8, 2);
			
			Console.WriteLine(tree.Numerator);
			Console.WriteLine(tree.Denominator);
			Console.WriteLine(tree);
			
			Console.ReadKey(true);
		}
	}
}