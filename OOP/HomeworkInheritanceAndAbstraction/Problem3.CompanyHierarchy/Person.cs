
using System;
using Problem3.CompanyHierarchy.Interfaces;

namespace Problem3.CompanyHierarchy
{
	public abstract class Person : IPerson
	{
		private int id;
		private	string firstName;
		private string lastName;
		
		protected Person(int id, string firstName, string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		
		public int Id 
		{
			get { return this.id; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ID cannot be negative");
                }
                this.id = value;
            }
		}		
	
		public string FirstName 
		{
			get { return this.firstName; }
			set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("name cannot be null");
                }
                this.firstName = value;
            }
		}		
		
		public string LastName 
		{
			get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("name cannot be null");
                }
                this.lastName = value; }
		}

        public override string ToString()
        {
            return string.Format("{0} {1}, ID: {2}", this.FirstName, this.LastName, this.Id);           
        }
    }
}
