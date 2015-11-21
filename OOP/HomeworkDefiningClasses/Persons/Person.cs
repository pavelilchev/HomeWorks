
using System;

namespace Persons
{
	public class Person
	{
		private string name;
		private int age;
		private string email;
		
		public Person(string name, int age)
			: this (name, age,  null)
		{			
		}
		
		public Person(string name, int age, string email)
		{
			this.Name = name;
			this.Age = age;
			this.Email = email;
		}
		
		
		public string Name {
			get { return name; }
			set {
				if (String.IsNullOrEmpty(value)) {
					throw new ArgumentNullException("Name cannot be null or empthy!");
				}
				name = value;
			}
		}	
		
		
		public int Age {
			get { return age; }
			set {
				if (value < 1 || value > 100) {
					throw new ArgumentOutOfRangeException("Age must be in range 1..100!");
				}
				age = value;
			}
		}
		
		
		public string Email {
			get { return email; }
			set { 
				if (value != null && !value.Contains("@")) {
					throw new ArgumentOutOfRangeException("Enter valid email!");
				}
				email = value; 
			}
		}
		
		public override string ToString()
		{
			return string.Format("Person: Name {0}, Age {1}, Email {2}", name, age, email??"none");
		}

	}
}