
using System;
using System.Linq;

namespace Problem2.Animals
{
	public class MainProgram
	{
		public static void Main(string[] args)
		{
			Cat catOne = new Cat("maca", 3, "female");
			Cat catTwo = new Cat("gaco", 5, "male");
			Dog dogOne = new Dog("Aqks", 7, "male");
			Dog dogTwo = new Dog("rex", 4, "male");
			Frog frogOne = new Frog("kikerica", 1, "female");
			Frog frogTwo = new Frog("skoklivka", 2, "female");
			Kitten kittenOne = new Kitten("murka", 1);
			Kitten kittenTwo = new Kitten("gushka", 2);
			TomCat tomCatOne = new TomCat("Zvqr", 7);
			TomCat tomCatTwo = new TomCat("Obesnik", 13);
			
			Animal[] animals = new Animal[10];
			animals[0] = catOne;
			animals[1] = catTwo;
			animals[2] = dogOne;
			animals[3] = dogTwo;
			animals[4] = frogOne;
			animals[5] = frogTwo;
			animals[6] = kittenOne;
			animals[7] = kittenTwo;
			animals[8] = tomCatOne;
			animals[9] = tomCatTwo;
			
			animals.GroupBy(animal => animal.GetType().Name)
				.ToList()
				.ForEach(group=> Console.WriteLine("Group name: {0}, Average age: {1}", group.Key, group.Average(x=>x.Age)));
			
			
			Console.ReadKey();
		}
	}
}