
using System;

namespace Problem1.HumanStudentWorker
{
	public abstract class Human
	{
		private string firstName;
		private string lastName;
		
		protected Human(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		
		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}
		public string LastName
		{
			get { return this.lastName; }
			set { this.lastName = value; }
		}
		
		public override string ToString()
		{
			return string.Format("Name: {0} {1}", firstName, lastName);
		}
	}
}
