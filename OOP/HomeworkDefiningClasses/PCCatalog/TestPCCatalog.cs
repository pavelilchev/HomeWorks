
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCCatalog
{
	class TestPCCatalog
	{
		public static void Main(string[] args)
		{
			List<Computer> computers = new List<Computer>();
			Console.WriteLine("Enter computer name");
			
			while (true) 
			{				
				String computerName = Console.ReadLine();
				List<Component> components = new List<Component>();
				
				
				Console.WriteLine("Enter component count");
				int count = int.Parse(Console.ReadLine());
				
				for (int i = 0; i < count; i++) 			
				{
					Console.WriteLine("Enter component name");
					String componentName = Console.ReadLine();
					Console.WriteLine("Enter component price");
					decimal componentPrice = decimal.Parse(Console.ReadLine());			
					Console.WriteLine("Enter component details");
					String componentDetails = Console.ReadLine();
			
					components.Add(new Component(componentName, componentPrice, componentDetails));
				}
				
				computers.Add(new Computer(computerName, components.ToArray()));
				
				Console.WriteLine("Exit - Y/N");			
				
				if (Console.ReadKey(true).Key == ConsoleKey.Y )
				{
					break;
				}
				              
			}

            computers.OrderByDescending(x => x.Price).ToList().ForEach(x => Console.WriteLine(x));			
		}
	}
}