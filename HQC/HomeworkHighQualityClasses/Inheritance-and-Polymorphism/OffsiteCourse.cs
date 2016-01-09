namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name, string teacherName, string town, params string[] students)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid town name");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();

            result += $"Town = {this.Town}}}";

            return result;
        }
    }
}
