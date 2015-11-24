
using System;

namespace Problem2.Animals
{
	public class Cat : Animal
	{
		public Cat(string name, int age, string gender)
			: base(name, age, gender)
		{
		}
		
		public override void ProduceSound()
		{
			Console.WriteLine("{0} said miaaaau", this.GetType().Name);
		}
	}
}
