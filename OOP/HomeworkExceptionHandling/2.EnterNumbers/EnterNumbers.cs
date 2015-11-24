using System;
using System.Collections.Generic;

namespace _2.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            List<int> numbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
              int number = ReadNumber(start, end);
                numbers.Add(number);
            }

            Console.WriteLine("Entered numbers");
            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            Console.WriteLine("Enter a number");            
            int number = 0;
            bool isVAlid = true;

            do
            {
                isVAlid = true;
                try
                {
                    string str = Console.ReadLine();
                    number = int.Parse(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid integer number in range [{0}...{1}]", start, end);
                    isVAlid = false;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Integer must be in range [{0}...{1}]", int.MinValue, int.MaxValue);
                    isVAlid = false;
                }                
            }
            while (!isVAlid);

            return number;
        }
    }
}
