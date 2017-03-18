namespace _4.Students
{
    public class Student
    {
        public Student()
        {
            Count++;
        }

        public static int Count = 0;
        public string Name { get; set; }
    }
}
