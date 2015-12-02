
using System;
using Problem1.Shapes.Interfaces;

namespace Problem1.Shapes
{
	class Program
	{
		public static void Main(string[] args)
		{
			IShape[] figures ={
				new Circle(3.5),
				new Rhombus(2.2, 3.3),
				new Rectangle(4.4, 5.5)
			};
			
			foreach (var figure in figures) 
			{
				Console.WriteLine(figure.CalculateArea());
				Console.WriteLine(figure.CalculatePerimeter());
				Console.WriteLine();
			}
			Console.ReadKey(true);
		}
	}
}