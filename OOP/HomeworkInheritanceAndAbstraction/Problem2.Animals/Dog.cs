
using System;

namespace Problem2.Animals
{
	public class Dog : Animal
	{
		public Dog(string name, int age, string gender)
			: base(name, age, gender)
		{
		}
		
		public override void ProduceSound()
		{
			Console.WriteLine("{0} said BauaBau", this.GetType().Name);
		}
	}
}
