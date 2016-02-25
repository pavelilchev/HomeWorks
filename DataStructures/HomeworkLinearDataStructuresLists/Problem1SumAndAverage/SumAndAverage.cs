namespace HomeworkLinearDataStructuresLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SumAndAverage
    {
        public static void Main()
        {
            long sum;
            double avg;
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                List<int> numbers = input.Split().Select(int.Parse).ToList();
                sum = numbers.Sum();
                avg = numbers.Average();
            }
            else
            {
                sum = 0;
                avg = 0;
            }

            Console.WriteLine("Sum={0}; Average={1}", sum, avg);
        }
    }
}
