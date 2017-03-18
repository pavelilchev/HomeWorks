namespace _1.DefineClassPerson
{
    using System;

    public class Program
    {
        static void Main()
        {
            var child = new Person
            {
                Name = "Dechko",
                Age = 1
            };

            var adult = new Person
            {
                Name = "Batko",
                Age = 21
            };

            Console.WriteLine(child);
            Console.WriteLine(adult);
        }
    }
}
