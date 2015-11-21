namespace SoftwareUniversityLearningSystem
{
    using System;

   public class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisit;

        public OnsiteStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse, int numberOfVisit) : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisit = numberOfVisit;
        }

        public int NumberOfVisit
        {
            get { return this.numberOfVisit; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Visit number cannot be negative");
                }
                this.numberOfVisit = value;
            }
        }
    }
}
