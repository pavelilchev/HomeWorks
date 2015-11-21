namespace SoftwareUniversityLearningSystem
{
    using System;

    public class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse) : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be null");
                }

                this.currentCourse = value;
            }
        }
    }
}
