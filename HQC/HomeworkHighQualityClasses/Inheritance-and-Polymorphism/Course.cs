namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        protected Course(string name, string teacherName, params string[] students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;

            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid course name.");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid teacher name.");
                }

                this.teacherName = value;
            }
        }

        private IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value ?? new List<string>();
            }
        }

        public void AddStudent(params string[] studentsList)
        {
            if (studentsList == null || studentsList.Length == 0)
            {
                throw new ArgumentNullException(nameof(studentsList), "Invalid student.");
            }

            foreach (var student in studentsList)
            {
                this.students.Add(student);
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            string result = $"{{ {string.Join(", ", this.Students)} }}";
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0} {{ Name = {1}; ", this.GetType().Name, this.Name);
            result.AppendFormat("Teacher = {0}; ", this.TeacherName);

            if (this.students == null || this.students.Count == 0)
            {
                result.Append("{ }");
            }
            else
            {
                result.AppendFormat("Students = {0}; ", this.GetStudentsAsString());
            }

            return result.ToString();
        }
    }
}
