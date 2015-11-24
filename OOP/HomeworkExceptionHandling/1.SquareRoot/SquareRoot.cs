using System;

namespace _1.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a integer number");
            string str = Console.ReadLine();

            try
            {
                int number = int.Parse(str);

                if (number < 0)
                {
                    throw new FormatException();
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
