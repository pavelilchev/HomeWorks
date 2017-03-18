namespace _4.Students
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var studentName = Console.ReadLine();
            while (studentName != "End")
            {
                var student = new Student();
                studentName = Console.ReadLine();
            }

            Console.WriteLine(Student.Count);
        }
    }
}
