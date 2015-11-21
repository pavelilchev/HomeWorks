namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Text;

    public class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string dropoutReason) : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Reason cannot be null");
                }

                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
           
            sb.Append("Dropout reason: " + this.DropoutReason);

            return sb.ToString();
        }
    }
}
