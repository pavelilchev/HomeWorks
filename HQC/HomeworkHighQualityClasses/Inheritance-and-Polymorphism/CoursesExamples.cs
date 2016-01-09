namespace InheritanceAndPolymorphism
{
    using System;

    public static class CoursesExamples
    {
        public static void Main()
        {
            Course localCourse = new LocalCourse("Databases", "Svetlin Nakov", "Enterprise");
            Console.WriteLine(localCourse);

            var students = new[] { "Peter", "Maria" };
            localCourse.AddStudent(students);
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            Course offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev",
                "Varna",
                new[] { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
