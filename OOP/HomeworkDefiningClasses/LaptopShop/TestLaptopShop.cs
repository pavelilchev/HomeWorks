
using System;

namespace LaptopShop
{
	class TestLaptopShop
	{
		public static void Main(string[] args)
		{
			Laptop fullLaptop = new	Laptop("Lenovo Yoga 2 Pro", 2259.00m,
"Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
8, "Intel HD Graphics 4400", "128GB SSD", @"13.3"" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", 4.5d,
new Battery("Li-Ion", 4, 2550 ));
			
			Laptop simpleLaptop = new Laptop("HP 250 G2", 699.00m);
			
			Console.WriteLine(fullLaptop);
			Console.WriteLine();			
			Console.WriteLine(simpleLaptop);
		}
	}
}