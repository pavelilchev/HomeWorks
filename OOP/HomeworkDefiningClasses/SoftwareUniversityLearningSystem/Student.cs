namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Text;

    public class Student : Person
    {
        private int studentNumber;
        private double averageGrade;

        public Student(string firstName, string lastName, int age, int studentNumber, double averageGrade) : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public int StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Student number must be positive");
                }
                this.studentNumber = value;
            }
        }

        public double AverageGrade
        {
            get { return this.averageGrade; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grades must be positive");
                }
                this.averageGrade = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("Student number: " + this.StudentNumber);
            sb.Append(Environment.NewLine);
            sb.Append("Average grades: " + this.AverageGrade);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
