
using System;

namespace Problem2.Animals
{
	public class Kitten : Cat
	{
		private const string KittenGender = "female";
		
		public Kitten(string name, int age)
			: base(name, age, Kitten.KittenGender)
		{
		}
		
		public override void ProduceSound()
		{
			Console.WriteLine("{0} said miamia", this.GetType().Name);
		}
	}
}
