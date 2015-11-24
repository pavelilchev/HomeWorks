
using System;
using System.Collections.Generic;

namespace Problem3.CompanyHierarchy
{
	class MainProgram
	{
		public static void Main(string[] args)
		{
			Manager managerOne = new Manager(12345, "Pavel", "Ilchev", 1500m, "Accounting");
			Manager managerTwo = new Manager(12346, "Natali", "Nikolova", 1400m, "Marketing");
			SalesEmployee saleOne = new SalesEmployee(12347, "Mimi", "Kovacheva", 950m, "Production");
			SalesEmployee saleTwo = new SalesEmployee(12348, "Plami", "Kaludova", 990m, "Marketing");
			Developer developerOne = new Developer(12349, "Eli", "Smerikarova", 800m, "Production");
			Developer developerTwo = new Developer(12350, "Nevi", "Todorova", 750m, "Sales");
			managerOne.AddEmployee(saleOne);
			managerOne.AddEmployee(developerOne);
			managerTwo.AddEmployee(saleTwo);
			managerTwo.AddEmployee(developerTwo);
            Sale car = new Sale("Car", 13500m, new DateTime(2015, 11, 24));
            saleOne.AddSale(car);
            Sale house = new Sale("House", 313500m, new DateTime(2015, 11, 22));
            saleOne.AddSale(house);
            Sale pen = new Sale("Pen", 1m, new DateTime(2015, 11, 24));
            saleTwo.AddSale(pen);
            Sale notebook = new Sale("NoteBook", 3m, new DateTime(2015, 11, 24));
            saleTwo.AddSale(notebook);
            Project companyHerarhy = new Project("Company Hierarchy", new DateTime(2015, 11, 24), "none");
            developerOne.AddProject(companyHerarhy);
            Project specialCalculator = new Project("Special Calculator", new DateTime(2015, 11, 25), "special");
            developerOne.AddProject(specialCalculator);
            Project bigGame = new Project("Big game", new DateTime(2015, 11, 26), "priority");
            developerTwo.AddProject(bigGame);
            Project ee = new Project("EE", new DateTime(2015, 11, 27), "secret");
            developerTwo.AddProject(ee);  
			
			List<Person> persons = new List<Person>();
			persons.Add(managerOne);
			persons.Add(managerTwo);
			persons.Add(saleOne);
			persons.Add(saleTwo);
			persons.Add(developerOne);
			persons.Add(developerTwo);

            persons.ForEach(pr => Console.Write(pr));

            Project test = new Project("Test", new DateTime(2015, 11, 25));
            Console.WriteLine();
            developerTwo.AddProject(test);
            developerOne.RemoveProject(test);
			
			Console.ReadKey();
		}
	}
}