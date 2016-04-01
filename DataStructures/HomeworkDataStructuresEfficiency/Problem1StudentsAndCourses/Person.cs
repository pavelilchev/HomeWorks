namespace Problem1StudentsAndCourses
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int CompareTo(Person other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
