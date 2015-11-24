
using System;

namespace Problem2.Animals
{
	public class TomCat : Cat
	{
		private const string TomCatGender = "male";
		
		public TomCat(string name, int age)
			: base(name, age, TomCat.TomCatGender)
		{
		}
		
		public override void ProduceSound()
		{
			Console.WriteLine("{0} said MQUUUU", this.GetType().Name);
		}
	}
}
