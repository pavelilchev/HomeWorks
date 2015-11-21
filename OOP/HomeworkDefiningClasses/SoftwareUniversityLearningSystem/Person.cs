namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Text;

    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Name cannot be less than 3 chars");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Name cannot be less than 3 chars");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age should be positive");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Name: " + this.FirstName + " " + this.LastName);
            sb.Append(Environment.NewLine);
            sb.Append("Age: " + this.Age);
            sb.Append(Environment.NewLine); 

            return sb.ToString();
        }
    }
}
