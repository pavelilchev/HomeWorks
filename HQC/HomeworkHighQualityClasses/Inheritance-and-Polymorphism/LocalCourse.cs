namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name, string teacherName, string lab, params string[] students) 
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid lab name.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();

            result += $"Lab = {this.Lab}}}";

            return result;
        }
    }
}
