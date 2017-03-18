namespace _2.CreatePersonConstructors
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter person info: ");
            var personInfo = Console.ReadLine().Split(',');

            Person person = null;
            if (string.IsNullOrWhiteSpace(personInfo[0]))
            {
                person = new Person(); 
            }
            else if (personInfo.Length == 1)
            {
                int age;
                bool isInt = int.TryParse(personInfo[0], out age);
                if (isInt)
                {
                    person = new Person(age);
                }
                else
                {
                    person = new Person(personInfo[0]);
                }
            }
            else if (personInfo.Length == 2)
            {
                int age;
                bool isInt = int.TryParse(personInfo[1], out age);
                if (!isInt)
                {
                    Console.WriteLine("Age should be integer number!");
                    return;
                }

                person = new Person(personInfo[0], int.Parse(personInfo[1]));
            }
            else
            {
                Console.WriteLine("Person can't have more than two parameters!");
                return;
            }

            Console.WriteLine(person);
        }
    }
}
