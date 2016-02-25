namespace Problem5CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CountOfOccurrences
    {
        public static void Main()
        {
            int[] numbers = null;

            try
            {
                numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Input cannot be null");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input should be single line integers splited whit space");
            }
            

            var occurrencesCounts = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (occurrencesCounts.ContainsKey(number))
                {
                    occurrencesCounts[number]++;
                }
                else
                {
                    occurrencesCounts[number] = 1;
                }
            }

            foreach (var pair in occurrencesCounts)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
