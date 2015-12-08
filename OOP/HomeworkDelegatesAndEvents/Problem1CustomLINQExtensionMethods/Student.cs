namespace Problem1CustomLINQExtensionMethods
{
   public class Student
    {
       public Student(string name, double grade)
       {
           Name = name;
           Grade = grade;
       }

       public string Name { get; set; }

       public double Grade { get; set; }
    }
}
