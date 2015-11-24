
using System;
using System.Linq;

namespace Problem1.HumanStudentWorker
{
	public class Student : Human
	{
		private string facultyNumber;
		
		public Student(string firstName, string lastName, string facultyNumber)
			: base(firstName, lastName)
		{
			this.FacultyNumber = facultyNumber;
		}
		
		public string FacultyNumber
		{
			get { return this.facultyNumber; }
			set 
			{
				if (value.Length < 5 || 
				    value.Length > 10 || 
				    value.Any(x => !char.IsDigit(x)))
				{
				    	throw new ArgumentOutOfRangeException("Faculty number should be between 5 and 10 digits");
				}
				    
				this.facultyNumber = value; 
			}
		}
		
		public override string ToString()
		{
			return base.ToString() + string.Format(", Faculty number {0}", facultyNumber);
		}
 
	}
}
